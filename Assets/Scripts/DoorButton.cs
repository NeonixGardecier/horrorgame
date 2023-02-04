using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public NightConfig config;

    public GameObject onLight;
    public GameObject availableLight;
    public GameObject unavailableLight;

    public GameObject door;

    public float onTime;
    public float cooldown;

    public bool available;

    void OnMouseDown()
    {
        if (available)
        {
            available = false;
            StartCoroutine(doorCycle());
        }
    }

    IEnumerator doorCycle()
    {
        availableLight.SetActive(true);
        door.SetActive(true);
        onLight.SetActive(true);
        config.officeDoorOpen = false;
        yield return new WaitForSeconds(onTime);
        onLight.SetActive(false);
        unavailableLight.SetActive(true);
        door.SetActive(false);
        config.officeDoorOpen = true;
        yield return new WaitForSeconds(cooldown);
        unavailableLight.SetActive(false);
        availableLight.SetActive(true);
        available = true;
    }
}
