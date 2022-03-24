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

    void Start() 
    {
        myLight = GetComponent<Light>();
    }
    void Update() 
    {
        DecraseLightAngle();
        DecraseLightIntensity();
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
        if(myLight.spotAngle <= minAngle)
        {
            return;
        }
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    void DecraseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
