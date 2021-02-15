using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo : MonoBehaviour
{
    private float Za_Warudo_Timer = 10;
    private float timer = 0;
    [SerializeField]
    private AudioSource TimeStop;
    [SerializeField]
    private KeyCode keyStart;

    public float WarudoStop = 0;
    public float moveTimer = 0;
    public bool ZaWarudoActive = false;
    public bool ZaWarudoReady = false;


    // Update is called once per frame
    void Update()
    {
        if (WarudoStop == 0)
        {
            timer += Time.deltaTime;
            if (timer >= Za_Warudo_Timer)
            {
                ZaWarudoReady = true;
                if (Input.GetKeyDown(keyStart))
                {
                    timer = 0f;
                    ZaWarudoStop();
                    //Debug.Log("Za Warudo");
                    moveTimer = 0f;
                }
            }
            else
            {
                ZaWarudoReady = false;
            }
        }
        if (WarudoStop == 1)
        {
            moveTimer += Time.deltaTime;
            //Debug.Log("Waurdo Stop");
            if (moveTimer >= 10)
            {
                ReturnTime();
                //Debug.Log("Move");
            }
        }
    }

    private void ZaWarudoStop()
    {
        TimeStop.Play();
        WarudoStop = 1;
        ZaWarudoActive = true;
    }
    private void ReturnTime()
    {
        WarudoStop = 0;
        moveTimer = 0f;
        ZaWarudoActive = false;
        ZaWarudoReady = false;
        //Debug.Log("Return Time");
    }
}
