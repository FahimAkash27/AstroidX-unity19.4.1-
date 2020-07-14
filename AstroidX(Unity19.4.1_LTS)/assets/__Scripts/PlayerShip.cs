﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    // This is a somewhat protected private singleton for PlayerShip
    static private PlayerShip   _S;
    static public PlayerShip    S
    {
        get
        {
            return _S;
        }
        private set
        {
            if (_S != null)
            {
                Debug.LogWarning("Second attempt to set PlayerShip singleton _S.");
            }
            _S = value;
        }
    }

    [Header("Set in Inspector")]
    public float        shipSpeed = 10f;
    public GameObject   bulletPrefab;

    Rigidbody           rigid;

    public GameObject playerParticalEffects;

    public int fireShots;


    void Awake()
    {
        S = this;

        // NOTE: We don't need to check whether or not rigid is null because of 
        //  [RequireComponent( typeof(Rigidbody) )] above
        rigid = GetComponent<Rigidbody>();

        if (!PlayerPrefs.HasKey("FireShots"))
        {
            fireShots = 0;
            PlayerPrefs.SetInt("FireShots", fireShots);
        }
        else
        {
            fireShots = PlayerPrefs.GetInt("fireShots");
        }
        
    }




    void Update()
    {
        // Using Horizontal and Vertical axes to set velocity
        float aX = Input.GetAxis("Horizontal");
        float aY = Input.GetAxis("Vertical");

        Vector3 vel = new Vector3(aX, aY);
        if (vel.magnitude > 1)
        {
            // Avoid speed multiplying by 1.414 when moving at a diagonal
            vel.Normalize();
        }

        rigid.velocity = vel * shipSpeed;

        // Mouse input for firing
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }


    void Fire()
    {
        // Get direction to the mouse
        Vector3 mPos = Input.mousePosition;
        mPos.z = -Camera.main.transform.position.z;
        Vector3 mPos3D = Camera.main.ScreenToWorldPoint(mPos);

        // Instantiate the Bullet and set its direction
        GameObject go = Instantiate<GameObject>(bulletPrefab);
        go.transform.position = transform.position;
        go.transform.LookAt(mPos3D);
        fireShots++;

        if (fireShots == 1000)
            AchivementManager.AM.TriggerHappy();
    }

    static public float MAX_SPEED
    {
        get
        {
            return S.shipSpeed;
        }
    }

    public void PlayerStartEffect()
    {
        Instantiate(playerParticalEffects, gameObject.transform.position, gameObject.transform.rotation);
    }
}
