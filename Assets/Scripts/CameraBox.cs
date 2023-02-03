using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    public GameObject ui;
    public FirstPersonMovement fpmScript;
    public GameObject defaultCam;

    void OnMouseDown()
    {
        OpenCams();
    }

    public void CloseCams()
    {
        ui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        fpmScript.speed = 5;
    }

    public void OpenCams()
    {
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        fpmScript.speed = 0;
        defaultCam.SetActive(true);
    }
}
