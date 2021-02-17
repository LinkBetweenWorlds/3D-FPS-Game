using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkDisplay : MonoBehaviour
{
    public bool BlinkReady;
    public Text blinkText;
    // Start is called before the first frame update
    void Start()
    {
        BlinkReady = false;
        blinkText.text = "Blink : Not Ready";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBlink();
        if (BlinkReady)
        {
            blinkText.text = "Blink : Ready";
        }
        else
        {
            blinkText.text = "Blink : Not Ready";
        }
    }
    private void UpdateBlink()
    {
        GameObject Player = GameObject.Find("Main Camera");

        TracerBlink Ready = Player.GetComponent<TracerBlink>();
        BlinkReady = Ready.BlinkReady;
    }
}
