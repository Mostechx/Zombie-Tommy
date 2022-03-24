using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] float angleRestoreAmount = 60f;
    [SerializeField] float intensityResotreAmount = 1f;

 

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(angleRestoreAmount);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityResotreAmount);
            Destroy(gameObject);
        }
    }
}
