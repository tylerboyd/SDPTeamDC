using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Tyler Boyd: 16951977
//Tobias McGee: 1323946

public class HealthSystem : MonoBehaviour{

    //public event EventHandler HealthChanged;

    private int health;
    private int maxHealth;
    public Transform healthBar;

    /*public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }*/

    public void SetUp(int max)
    {
        maxHealth = max;
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

        healthBar.Find("Bar").localScale = new Vector3((this.GetHealthPercentage()/100), 1, 1);
        /*if (HealthChanged != null)
        {
            HealthChanged(this, EventArgs.Empty);
        }*/

        return;
    }

    public int Damage_Test(int damageAmount, int health)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
        return health;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.Find("Bar").localScale = new Vector3((this.GetHealthPercentage() / 100), 1, 1);

        return;
        /*if (HealthChanged != null)
        {
            Debug.LogFormat("Health Change");
            HealthChanged(this, EventArgs.Empty);
        }*/
    }
}
