using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public Text healthPanel;
    public int health = 100;

    private void Start()
    {
        ApplyDamage(0);
    }

    void ApplyDamage(int damage)
    {
        if(healthPanel != null && health > 0)
        {
            health = health - damage;
            healthPanel.text = "Health : " + health.ToString();
        }
    }
}
