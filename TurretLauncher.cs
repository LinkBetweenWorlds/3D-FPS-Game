using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretLauncher : MonoBehaviour
{
    public GameObject spawn;
    public float kickDistance = 300.0f;
    public KeyCode spawnKey;
    private bool spawned;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey) && spawned == false)
        {
            spawned = true;
            var clone = Instantiate(spawn, gameObject.transform.position, gameObject.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * kickDistance);
        }
    }
}