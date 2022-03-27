using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;
    bool isLightActive = false;

    void Start() 
    {
        myLight = GetComponent<Light>();
    }
    void Update() 
    {
        DecraseLightAngle();
        DecraseLightIntensity();
        if(!isLightActive)
        {
            myLight.enabled = false;
        }

        if(Input.GetButtonDown("Submit"))
        {
            if(isLightActive == false)
            {
                myLight.enabled = true;
                isLightActive = true;
            }
            else
            {
                myLight.enabled = false;
                isLightActive = false;
            }
        }
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }
    public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    void DecraseLightAngle()
    {
        if(!isLightActive) return;
        if(myLight.spotAngle <= minAngle)
        {
            return;
        }
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    void DecraseLightIntensity()
    {
        if(!isLightActive) return;
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
