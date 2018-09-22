using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tobias McGee: 1323946

public class PlayerHealth : MonoBehaviour {

    public Rigidbody2D rb2D;
    Animator anim;

    public int health;
    public GameObject bloodSplash;
    public float attackTime;
    private float attackTimeCounter;
    private bool attacking;
    

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //If the player has been damaged within set attack time, disallow any other attacks. If the time has run out, re-enable damage
        if (attackTimeCounter <= 0)
        {
            attacking = false;
        }
        else if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        //If health reaches 0, kill player and send to game over screen
        if (health <= 0)
        {
            //TODO: switch scene to Game Over
            Destroy(gameObject);

            //SoundManager.Instance.RandomPlayEnemyDeadSource(enemyDeadSound1, enemyDeadSound2);
            Debug.LogFormat(gameObject.name + " was killed");
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            if(attacking == false)
            {
                attacking = true;
                attackTimeCounter = attackTime;
                health -= col.gameObject.GetComponent<EnemyFollow>().damage;
            }
        }
    }
}
