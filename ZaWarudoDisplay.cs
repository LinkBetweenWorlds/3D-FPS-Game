using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZaWarudoDisplay : MonoBehaviour
{
    public bool ZaWarudoReady = false;
    private bool ZaWarudoActive = false;
    public Text warudoText;
    private float ZaWarudoTimer;
    private float TimeLeft;

    private void Start()
    {
        ZaWarudoReady = false;
        ZaWarudoActive = false;
        warudoText.text = "Za Warudo: Not Ready";
    }
    private void Update()
    {
        UpdateWarudo();
        if (ZaWarudoActive)
        {
            ZaWarudoTimer = (int)ZaWarudoTimer;
            TimeLeft = 10 - ZaWarudoTimer;
            TimeLeft = (int)TimeLeft;
            warudoText.text = "Za Warudo: " + TimeLeft.ToString() + " seconds left";
        }
        else if (ZaWarudoReady == false && ZaWarudoActive == false)
        {
            warudoText.text = "Za Warudo: Not Ready";
            TimeLeft = 10;
        }
        else if (ZaWarudoReady == true && ZaWarudoActive == false)
        {
            warudoText.text = "Za Warudo: Ready";
        }
    }

    private void UpdateWarudo()
    {
        GameObject thePlayer = GameObject.Find("Player");

        ZaWarudo Ready = thePlayer.GetComponent<ZaWarudo>();
        ZaWarudoReady = Ready.ZaWarudoReady;

        ZaWarudo Active = thePlayer.GetComponent<ZaWarudo>();
        ZaWarudoActive = Active.ZaWarudoActive;

        ZaWarudo Timer = thePlayer.GetComponent<ZaWarudo>();
        ZaWarudoTimer = Timer.moveTimer;
    }
}
