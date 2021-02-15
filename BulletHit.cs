using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject particle;
    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("bullet"))
        {
            ContactPoint contact = other.contacts[0];

            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(particle, pos, rot);
            //Destroy(gameObject);
            //Debug.Log("false");
            gameObject.SetActive(false);
        }
    }
}
