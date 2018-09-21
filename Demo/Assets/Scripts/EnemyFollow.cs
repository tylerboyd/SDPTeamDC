using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556
//Andrew Bycroft: 16948980
//Tobias McGee: 1323946

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
        /*
        if (col.gameObject==wall)
        {
            isMoving = false;
            Vector3 hit = col.contacts[0].normal;
            Debug.Log(hit);
            float angle = Vector3.Angle(hit, Vector3.up);

            if (Mathf.Approximately(angle, 0))
            {
                //Down
                Debug.Log("Down");
            }
            if (Mathf.Approximately(angle, 180))
            {
                //Up
                Debug.Log("Up");
            }
            if (Mathf.Approximately(angle, 90))
            {
                // Sides
                Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                if (cross.y > 0)
                { // left side of the player
                    Debug.Log("Left");
                }
                else
                { // right side of the player
                    Debug.Log("Right");
                }
            }
            
        }
        */
        if(col.gameObject.name.Equals("Player"))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            isMoving = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage dealt");
    }
}
