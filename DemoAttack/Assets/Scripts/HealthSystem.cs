using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Tyler Boyd: 16951977

public class HealthSystem : MonoBehaviour{

    public event EventHandler HealthChanged;

    private int health;
    private int maxHealth;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercentage()
    {
        return (float)health / maxHealth * 100;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
           health = 0;
        }
        if (HealthChanged != null)
        {
            HealthChanged(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (HealthChanged != null)
        {
            HealthChanged(this, EventArgs.Empty);
        }
    }
}
