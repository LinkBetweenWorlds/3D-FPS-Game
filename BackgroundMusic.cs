using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource BM;

    [SerializeField]
    KeyCode keyPositive;
    [SerializeField]
    KeyCode keyNegative;
    private float TimeStop;

    // Start is called before the first frame update
    void Start()
    {
        BM.Play();
        GameObject thePlayer = GameObject.Find("Player");
        ZaWarudo FreezeTime = thePlayer.GetComponent<ZaWarudo>();
        TimeStop = FreezeTime.WarudoStop;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyPositive) || TimeStop == 0)
            BM.UnPause();

        if (Input.GetKey(keyNegative) || TimeStop == 1)
            BM.Pause();
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
