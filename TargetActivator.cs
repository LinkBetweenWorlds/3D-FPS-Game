using UnityEngine;

public class TargetActivator : Triggerable
{
    public bool deactivateOnAwake = true;

    private void Awake()
    {
        if (deactivateOnAwake)
        {
            gameObject.SetActive(false);
        }
    }

    public override void Trigger(TriggerAction action)
    {
        if(action == TriggerAction.Activate)
        {
            gameObject.SetActive(true);
        }
        else if(action == TriggerAction.Deactivate)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}