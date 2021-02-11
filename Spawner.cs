using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public int amount = 1;
    public float delaySpawn = 1;

    private int getAmount;
    private float timer;
    private int spawned;

    private void Start()
    {
        ResetRound();
    }

    private void ResetRound()
    {
        getAmount = amount;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(delaySpawn < timer)
        {
            if(spawned < getAmount)
            {
                timer = 0;
                spawned++;
                GameObject instance = Instantiate(spawn, transform);
                instance.transform.parent = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (spawn != null)
        {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh, transform.position, spawn.transform.rotation, Vector3.one);
        }
    }
}
