using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    public GameObject projectile;

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            
            Destroy(clone, 5.0f);
        }
    }
}
