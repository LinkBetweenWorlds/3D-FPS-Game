﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;
    private float TimeStop = 0;

    private void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        ZaWarudo FreezeTime = thePlayer.GetComponent<ZaWarudo>();
        TimeStop = FreezeTime.WarudoStop;
    }
    private void Update()
    {
        if (TimeStop == 1)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
    private void FixedUpdate()
    {
        UpdateTime();
    }
    private void UpdateTime()
    {
        GameObject thePlayer = GameObject.Find("Player");
        ZaWarudo FreezeTime = thePlayer.GetComponent<ZaWarudo>();
        TimeStop = FreezeTime.WarudoStop;
        //Debug.Log(TimeStop);
        //Debug.Log("Time Stop");
    }
}
