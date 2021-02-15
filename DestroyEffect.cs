using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float maxTime = 1;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
