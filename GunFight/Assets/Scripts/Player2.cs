﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2 : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    float xMin = 6f;
    [SerializeField] float xMax;
    float yMin;
    float yMax;
    [SerializeField] float Ypadding = .5f;
    [SerializeField] float Xpadding = 1f;

    [SerializeField] float health = 50;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] float bulletDamage = 25f;

    

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBoundries();
    }

    void Update()
    {
        
        healthText.text = health.ToString();
    }

    

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        

        var deltaX = Input.GetAxis("Horizontal2") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical2") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Bullet1")
        {
            affectHealth(-bulletDamage);
            moveSpeed *= (health / 100);
        }
    }

    void affectHealth(float healthChange)
    {
        health += healthChange;
        if(health <= 0)
        {
            health = 0;
            //Doesntly allow health to fall under 0
        }
    }

    private void setUpMoveBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = 6f;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + Xpadding;
        
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Ypadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Ypadding;
    }
}
