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

    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsController.mouseLook.XSensitivity = zoomedInXSens;
                fpsController.mouseLook.YSensitivity = zoomedInYSens;
                FPCam.fieldOfView = zoomedInFOV;
            }
            else
            {
                zoomedInToggle = false;
                fpsController.mouseLook.XSensitivity = zoomedOutXSens;
                fpsController.mouseLook.YSensitivity = zoomedOutYSens;
                FPCam.fieldOfView = zoomedOutFOV;
            }
        }
 

    }
}
