using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Tyler Boyd: 16951977

public class HealthSystem : MonoBehaviour{

    public event EventHandler HealthChanged;

    private int health;
    private int maxHealth;

    //takes in a maximum health value for an entity, and sets health to that value.
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
        //If health goes below zero, sets health to zero.
        if (health < 0)
        {
           health = 0;
        }
        //Only updates health bar if entities health changes
        if (HealthChanged != null)
        {
            HealthChanged(this, EventArgs.Empty);
        }
    }

    //Heal function
    public void Heal(int healAmount)
    {
        health += healAmount;
        //If healed above maxhealth value, sets health to maxhealth.
        if (health > maxHealth) 
        {
            health = maxHealth;
        }
        //Only updates health bar if entities health changes
        if (HealthChanged != null)
        {
            HealthChanged(this, EventArgs.Empty);
        }
    }
}
