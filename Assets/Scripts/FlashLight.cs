using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlashLight : MonoBehaviour
{
    public NightConfig config;
    public GameObject flashlight;

    public bool isOn;

    public TextMeshProUGUI powerText;

    void Update()
    {
        UpdateLightStatus();
        CheckInput();

        powerText.text = "Power : " + config.power + "%";
    }

    void UpdateLightStatus()
    {
        if(config.power >= 1 && isOn && config.jumpScareInProgress == false)
        {
            flashlight.SetActive(true);
        }
        else if(config.power < 1 || isOn == false || config.jumpScareInProgress)
        {
            flashlight.SetActive(false);
        }
    }

    void CheckInput()
    {
        if(isOn && Input.GetMouseButtonDown(1))
        {
            isOn = false;
        }
        else if(isOn == false && Input.GetMouseButtonDown(1))
        {
            isOn = true;
        }
    }

    void Start()
    {
        StartCoroutine(flashlightCycle());
    }

    IEnumerator flashlightCycle()
    {
        yield return new WaitForSeconds(2.5f);
        if (config.power > 0 && isOn)
        {  
            config.power -= 1;
        }
        StartCoroutine(flashlightCycle());
    }
}
