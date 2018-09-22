using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tobias McGee: 1323946
//Andrew Bycroft: 16948980

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

        //If health reaches 0, kill player and send to game over screen
        if (health <= 0)
        {
            //TODO: switch scene to Game Over
            Destroy(gameObject);

            //SoundManager.Instance.RandomPlayEnemyDeadSource(enemyDeadSound1, enemyDeadSound2);
            Debug.LogFormat(gameObject.name + " was killed");
        }

    }

    public void TakeDamage(int damage)
    {
        //Only let the player take damage set by the attack time
        if (attackTimeCounter <= 0)
        {
            attackTimeCounter = attackTime;
            attacking = true;
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            health -= damage;

            //SoundManager.Instance.RandomPlayEnemyTakingDemageSource(enemyTakingDemageSound1, enemyTakingDemageSound2);
            Debug.LogFormat("Damage dealt to " + gameObject.name);
        }
        else if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
    }
}

//private void OnCollisionEnter2D(Collision2D col)
//    {
//        if (col.gameObject.tag.Equals("Enemy"))
//        {
//            if(attacking == false)
//            {
//                attacking = true;
//                attackTimeCounter = attackTime;
//                health -= col.gameObject.GetComponent<EnemyFollow>().damage;
//            }
//        }
//    }
//}
