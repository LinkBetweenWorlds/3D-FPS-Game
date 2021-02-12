﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyDamage : MonoBehaviour
{
    private int hitNumber;

    private void OnEnable()
    {
        hitNumber = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("bullet"))
        {
            hitNumber++;
        }
        if(hitNumber >= 3)
        {
            gameObject.SetActive(false);
        }
    }
}
