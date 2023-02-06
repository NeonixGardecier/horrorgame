using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public NightConfig config;
    public float powerDrainTimer;

    public GameObject onLight;
    public GameObject availableLight;
    public GameObject unavailableLight;

    public GameObject door;

    public bool available = true;
    public bool doorOn;

    public GameObject buttonSound;

    void OnMouseDown()
    {
        if (doorOn == false && available)
        {
            doorOn = true;
        }
        else if (doorOn)
        {
            doorOn = false;
        }
        config.PlaySound(buttonSound, 0.206f);
    }

    void Start()
    {
        StartCoroutine(doorCycle());
    }

    void Update()
    {
        UpdateDoorStatus();
        CheckAvailability();
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (available)
        {
            if(doorOn)
            {
                onLight.SetActive(true);
                availableLight.SetActive(false);
                unavailableLight.SetActive(false);                
            }
            if(doorOn == false)
            {
                onLight.SetActive(false);
                availableLight.SetActive(true);
                unavailableLight.SetActive(false);                
            }
        }else{
            onLight.SetActive(false);
            availableLight.SetActive(false);
            unavailableLight.SetActive(true);
        }
    }

    void CheckAvailability()
    {
        if (config.power > 0)
        {
            available = true;
        }
        else if (config.power < 1)
        {
            available = false;
            doorOn = false;
        }
    }

    void UpdateDoorStatus()
    {
        if (doorOn && config.power > 0 && available)
        {
            door.SetActive(true);
            config.officeDoorOpen = false;
        }
        else if(doorOn == false || config.power < 1 || available == false)
        {
            door.SetActive(false);
            config.officeDoorOpen = true;
        }
    }

    IEnumerator doorCycle()
    {
        yield return new WaitForSeconds(powerDrainTimer);
        if(doorOn)
        {
            config.power -= 1;
        }
        StartCoroutine(doorCycle());
    }
}
