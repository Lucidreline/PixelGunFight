﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    float bulletSpeed;
    int ammoCount;
    [SerializeField] GameObject muzzleFlash;
    MuzzleFlash flashScript;
    [SerializeField] TextMeshProUGUI ammoCountText;

    [SerializeField] GameObject gameManager;
    void Start()
    {
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
        bulletSpeed = gameManagerScript.GetBulletSpeed();
        ammoCount = gameManagerScript.GetStartBulletCount();
        flashScript = muzzleFlash.GetComponent<MuzzleFlash>();
    }

    void Update()
    {
        ammoCountText.text = ammoCount.ToString();
        fire(); 
    }

    public void AddAmmo(int howMuchAmmo)
    {
        ammoCount += howMuchAmmo;
        if (ammoCount < 0)
        {
            ammoCount = 0;
        }
    }

    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            if(ammoCount > 0)
            {
                flashScript.ActivateFlash();
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                ammoCount--;
            }
            
        }
    }
}
