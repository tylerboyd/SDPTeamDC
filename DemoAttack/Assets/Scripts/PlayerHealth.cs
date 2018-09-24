using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tobias McGee: 1323946
//Andrew Bycroft: 16948980

public class PlayerHealth : MonoBehaviour {

    public Rigidbody2D rb2D;
    public HealthSystem healthSystem;
    Animator anim;

    public int maxHealth;
    public GameObject bloodSplash;
    public float attackTime;
    private float attackTimeCounter;
    private bool attacking;
    

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthSystem.SetUp(maxHealth);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //If health reaches 0, kill player and send to game over screen
        if (healthSystem.GetHealth() <= 0)
        {
            //TODO: switch scene to Game Over
            Destroy(gameObject);

            //SoundManager.Instance.RandomPlayEnemyDeadSource(enemyDeadSound1, enemyDeadSound2);
            Debug.LogFormat(gameObject.name + " was killed");
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        //Only let the player take damage when the counter is at zero
        if (attackTimeCounter <= 0)
        {
            attackTimeCounter = attackTime;
            attacking = true;
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            healthSystem.Damage(damage);

            //SoundManager.Instance.RandomPlayEnemyTakingDemageSource(enemyTakingDemageSound1, enemyTakingDemageSound2);
            Debug.LogFormat("Damage dealt to " + gameObject.name);
        }
    }
}
