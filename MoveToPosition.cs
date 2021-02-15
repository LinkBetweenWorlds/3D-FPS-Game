using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    public float knockbackTime = 1;
    public float kick = 1.8f;
    private Transform goal;
    private NavMeshAgent agent;
    private bool hit;
    private ContactPoint contact;
    private float timer;
    private float TimeStop = 0;

    private void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        timer = knockbackTime;
        GameObject thePlayer = GameObject.Find("Player");
        ZaWarudo FreezeTime = thePlayer.GetComponent<ZaWarudo>();
        TimeStop = FreezeTime.WarudoStop;
    }

    private void Update()
    {
        if (TimeStop == 1)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            if (hit)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * kick, contact.point, ForceMode.Impulse);
                hit = false;
                timer = 0;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                timer += Time.deltaTime;
                if (knockbackTime < timer)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                    agent.SetDestination(goal.position);
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("bullet"))
        {
            contact = other.contacts[0];
            hit = true;
        }
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
