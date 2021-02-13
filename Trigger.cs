using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerAction action = TriggerAction.Activate;
    public Triggerable[] targets;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTargets();
        }
    }

    public void TriggerTargets()
    {
        foreach (Triggerable t in targets)
        {
            if (t != null)
            {
                t.Trigger(action);
            }
        }
    }
    // Gizmos function for the Trigger
    void OnDrawGizmos()
    {
        //Draw a cube to make it possible to select the trigger in the scene view
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position,
       Vector3.one * 0.25f);
        // This first null check avoids an editor error on creation of the Trigger
        if (targets != null)
        {
            foreach (Triggerable t in targets)
            {
                if (t != null)
                {
                    Gizmos.DrawLine(transform.
                   position, t.transform.position);
                }
            }
        }
    }
}