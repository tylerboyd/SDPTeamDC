using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556
//Andrew Bycroft: 16948980
//Tobias McGee: 1323946
//Larry Zhao: 15913026

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    public float speed;
    public Rigidbody2D rb;
    public bool isMoving;
    private int direction;
    public Animator anim;
    private GameObject enemy;
    public GameObject bloodSplash;
    public int health;
    private GameObject player;

    //The delay between attacking time, so animation is not spammed.
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    //For calculating if the player is in range
    private CircleCollider2D range;
    private bool playerInRange;

    public Transform attackPos;
    public float attackRange;
    public int damage;

    public AudioClip enemyDeadSound1;
    public AudioClip enemyDeadSound2;
    public AudioClip enemyTakingDemageSound1;
    public AudioClip enemyTakingDemageSound2;

    // Use this for initialization
    void Start ()
    {
        //Sets the enemy to find the game object named "Hero" aka our character
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
        playerInRange = false;
        range = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Hero");
        direction = anim.GetInteger("Direction");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the player character is far enough away, start moving
        if(Vector3.Distance(transform.position, target.position) > 3.0f)
        {
            isMoving = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }

        //Checks how far the enemy is from the Hero. If it is close, change it to a kinematic rigidbody 
        //to stop it from moving the Hero and other enemies. This also stops the Hero from moving the enemies.
        //Otherwise move toward the Hero.

        if (isMoving)
        {
            if (Vector3.Distance(transform.position, target.position) <= 1.0f)
            {
                rb.isKinematic = true;
                return;
            }
            else
            {
                rb.isKinematic = false;
                //Moves the enemies position towards the target("Hero") against a fixed speed
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }

        //Kill the enemy if their health drops to 0 or below
        if (health <= 0)
        {
            Destroy(gameObject);

            SoundManager.Instance.RandomPlayEnemyDeadSource(enemyDeadSound1, enemyDeadSound2);
            Debug.LogFormat( gameObject.name + " was killed");
        }

        //Attack the hero if in range
        if(playerInRange == true)
        {
            if (attackTimeCounter <= 0)
            {
                attackTimeCounter = attackTime;
                attacking = true;

                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                Debug.LogFormat("Counter reset");

            }
            else if (attackTimeCounter > 0)
            {
                attackTimeCounter -= Time.deltaTime;
            }
        }
        
        //Changes enemy facing direction towards the player
        //The Direction is Clockwise, 1,2,3,4; up,right,down,left respectively
        //right = 2
        if (anim.GetFloat("MoveX") > 0.0f)
        {
            anim.SetInteger("Direction", 2);
        }

        //left = 4
        if (anim.GetFloat("MoveX") < 0.0f)
        {
            anim.SetInteger("Direction", 4);
        }

        //up = 1
        if (anim.GetFloat("MoveY") > 0.0f)
        {
            anim.SetInteger("Direction", 1);
        }

        //down = 3
        if (anim.GetFloat("MoveY") < 0.0f)
        {
            anim.SetInteger("Direction", 3);
        }


        anim.SetFloat("MoveX", enemy.transform.position.x);
        anim.SetFloat("MoveY", enemy.transform.position.y);
        anim.SetInteger("Direction", direction);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            isMoving = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playerInRange = true;
            //Debug.LogFormat("Player entered range");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            playerInRange = false;
            //Debug.LogFormat("Player left range");
        }
    }

    /*void OnCollisionStay2D(Collision2D col)
    {
            if (attackTimeCounter <= 0)
            {
                attacking = false;

                if (col.gameObject.name.Equals("Player"))
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    //rb.velocity = Vector2.zero;

                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<PlayerHealth>().TakeDamage(damage);
                    }
                }
            else if (attackTimeCounter > 0)
            {
                //timeBtwAttack from blackthornprod
                //SoundManager.Instance.RandomPlayAttackSource(attackSound1, attackSound2);
                attackTimeCounter -= Time.deltaTime;
            }
        }
    }*/

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
        health -= damage;

        SoundManager.Instance.RandomPlayEnemyTakingDemageSource(enemyTakingDemageSound1, enemyTakingDemageSound2);
        Debug.LogFormat("Damage dealt to " + gameObject.name);
    }
}
