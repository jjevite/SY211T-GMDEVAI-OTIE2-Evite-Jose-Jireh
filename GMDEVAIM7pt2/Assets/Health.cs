using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get { return maxHealth; } }
    private float maxHealth; 


    public void Initialize(float maxHealth)
    {
        this.maxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damageToTake)
    {
        CurrentHealth -= damageToTake;
        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }
}
