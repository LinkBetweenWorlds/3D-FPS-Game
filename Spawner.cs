using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public GameObject go;
    public bool active;
    public Enemy (GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public int amount = 1;
    public float delaySpawn = 1;
    public bool spawnsDead;

    private int getAmount;
    private float timer;
    private int spawned;
    private int enemyDead;

    public List<Enemy> enemies = new List<Enemy>();

    public void Start()
    {
        GameManager.RoundComplete += ResetRound;
        ResetRound();
        while(spawned < getAmount)
        {
            spawned++;
            GameObject instance = Instantiate(spawn, transform);
            enemies.Add(new Enemy(instance, false));
            instance.transform.parent = null;
            instance.SetActive(false);
        }
        ResetRound();
    }
    public void ResetRound()
    {
        spawnsDead = false;
        getAmount = amount;
        spawned = 0;
        timer = 0;
        enemyDead = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(delaySpawn < timer)
        {
            if(spawned < getAmount)
            {
                timer = 0;
                enemies[spawned].active = true;
                enemies[spawned].go.SetActive(true);
                StartCoroutine(SetKinematic(spawned));
                spawned++;
            }
            for(int i = enemies.Count - 1; i >= 0; i--)
            {
                if(enemies[i].go.activeSelf == false && enemies[i].active == true)
                {
                    enemies[i].go.transform.position = transform.position;
                    enemies[i].active = false;
                    enemyDead++;
                }
            }
            if(enemyDead == enemies.Count)
            {
                spawnsDead = true;
            }
        }
    }

    IEnumerator SetKinematic(int id)
    {
        yield return null;
        enemies[id].go.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(spawn != null)
        {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh, transform.position, spawn.transform.rotation, Vector3.one);
        }
    }
}
