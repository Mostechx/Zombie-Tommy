using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] AudioClip pistolGunshot;
    [SerializeField] AudioClip carbineGunshot;
    [SerializeField] AudioClip shotgunGunshot;

    AudioSource AS;
    Weapon weapon;

    void Start()
    {
        SetWeaponActive();
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();
        ProcessGunshots();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void ProcessGunshots()
    {
        weapon = GetComponentInChildren<Weapon>();
        if(Input.GetMouseButtonDown(0) && weapon.CanShoot())
        {
            if(currentWeapon == 0)
            {
                AS.Stop();
                AS.PlayOneShot(pistolGunshot);
            }
            if(currentWeapon == 1)
            {
                AS.Stop();
                AS.PlayOneShot(shotgunGunshot);
            }
            if(currentWeapon == 2)
            {
                AS.Stop();
                AS.PlayOneShot(carbineGunshot);
            }
        }
    }

    void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
 
}
