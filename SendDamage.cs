using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    public int damageAmount = 1;
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.SendMessage("ApplyDamage", damageAmount);
        }
    }
}
