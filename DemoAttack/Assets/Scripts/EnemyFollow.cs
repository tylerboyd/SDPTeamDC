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
    public bool isMoving, playerMoving;
    private Vector2 lastMove;
    private Animator anim;
    private GameObject enemy;
    public GameObject bloodSplash;
    public int health;

    //The delay between attacking time, so animation is not spammed.
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
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

        /*****************************************
        Not needed for sprint 1
        *****************************************/
        /*
        //Changes enemy facing direction towards the player
        //left and right
        if (enemy.transform.position.x > 0.0f || enemy.transform.position.x < -0.0f)
        {
            playerMoving = true;
            lastMove = new Vector2(enemy.transform.position.x, 0f);
        }

        if (enemy.transform.position.y > 0.0f || enemy.transform.position.y < -0.0f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, enemy.transform.position.y);
        }

        anim.SetFloat("MoveX", enemy.transform.position.x);
        anim.SetFloat("MoveY", enemy.transform.position.y);
        anim.SetBool("isMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        */
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

    void OnCollisionStay2D(Collision2D col)
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
    }

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
