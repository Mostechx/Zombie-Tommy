using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damageValue = 15f;
    [SerializeField] float shootDelay = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;


    bool canShoot = true;
    void OnEnable() 
    {
        canShoot = true;
    }
    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    void DisplayAmmo()
    {
        int currentAmmo = AmmoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (AmmoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            AmmoSlot.reduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damageValue);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    
}
