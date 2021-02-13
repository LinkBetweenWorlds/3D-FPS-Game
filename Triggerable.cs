using UnityEngine;
public enum TriggerAction
{
    Activate,
    Deactivate,
    Toggle,
}
public abstract class Triggerable :
MonoBehaviour
{
    public abstract void Trigger(TriggerAction
   action);
    public class Door : Triggerable
    {
        public override void Trigger(TriggerAction
       action)
        {
        }
    }
}
