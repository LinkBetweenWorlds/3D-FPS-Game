using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    private float maxTime = 30;
    private float timer;
    private float TimeStop = 0;

    private void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        ZaWarudo FreezeTime = thePlayer.GetComponent<ZaWarudo>();
        TimeStop = FreezeTime.WarudoStop;
        //Debug.Log("Fire");
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            Destroy(gameObject);
            //Debug.Log("TimeUp");
        }
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
    private void DestroyAfterTime()
    {
        Destroy(gameObject, maxTime * Time.deltaTime);
    }
}
