using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour
{
    public GameObject onLight;
    public GameObject availableLight;
    public GameObject unavailableLight;

    public GameObject light;

    public float onTime;
    public float cooldown;

    public bool available;

    void OnMouseDown()
    {
        if (available)
        {
            available = false;
            StartCoroutine(lightCycle());
        }
    }

    IEnumerator lightCycle()
    {
        availableLight.SetActive(true);
        light.SetActive(true);
        onLight.SetActive(true);
        yield return new WaitForSeconds(onTime);
        onLight.SetActive(false);
        unavailableLight.SetActive(true);
        light.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        unavailableLight.SetActive(false);
        availableLight.SetActive(true);
        available = true;
    }
}
