using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float zoomedOutFOV = 60f;


    [SerializeField] float zoomedInXSens = 1f;
    [SerializeField] float zoomedOutXSens = 2f;
    [SerializeField] float zoomedInYSens = 1f;
    [SerializeField] float zoomedOutYSens = 2f;


    [SerializeField] Camera FPCam;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    public bool zoomedInToggle = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }


    void ZoomIn()   
    {
        zoomedInToggle = true;
        fpsController.mouseLook.XSensitivity = zoomedInXSens;
        fpsController.mouseLook.YSensitivity = zoomedInYSens;
        FPCam.fieldOfView = zoomedInFOV;
    }
    void ZoomOut()
    {
        zoomedInToggle = false;
        fpsController.mouseLook.XSensitivity = zoomedOutXSens;
        fpsController.mouseLook.YSensitivity = zoomedOutYSens;
        FPCam.fieldOfView = zoomedOutFOV;
    }

    

    void OnDisable() 
    {
        ZoomOut();
    }
}
