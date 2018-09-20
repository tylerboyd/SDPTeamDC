using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556
//Andrew Bycroft: 16948980

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    public float speed;
    public float speed2 = 0;
    public Rigidbody2D rb;
    public bool isMoving, playerMoving;
    private Vector2 lastMove;
    private Animator anim;
    private GameObject enemy;
    private GameObject wall;

    // Use this for initialization
    void Start ()
    {
        //Sets the enemy to find the game object named "Hero" aka our character
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        wall = GameObject.FindGameObjectWithTag("Collision_Wall");
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMoving = true;

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

        //Checks how far the enemy is from the Hero. If it is close, change it to a kinematic rigidbody 
        //to stop it from moving the Hero and other enemies. This also stops the Hero from moving the enemies.
        //Otherwise move toward the Hero.
        //this ray will generate a vector which points from the center of 
        //the falling object TO object hit. You subtract where you want to go from where you are


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

        //var direction = Vector3.zero;
        //float distanceToStop = 1.0f;
        //if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        //{
        //    direction = target.position - transform.position;
        //    rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);

        //}
    }


    void OnCollisionEnter2D(Collision2D col)
    {
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
                transform.position = Vector2.MoveTowards(transform.position, transform.up*10, speed * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, transform.right*10, speed * Time.deltaTime);
            }
            if (Mathf.Approximately(angle, 180))
            {
                //Up
                Debug.Log("Up");
                transform.position = Vector2.MoveTowards(transform.position, -transform.up*10, speed * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, transform.right*5, speed * Time.deltaTime);
            }
            if (Mathf.Approximately(angle, 90))
            {
                // Sides
                Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                if (cross.y > 0)
                { // left side of the player
                    Debug.Log("Left");

                    transform.position = Vector2.MoveTowards(transform.position, transform.right*10, speed * Time.deltaTime);
                    transform.position = Vector2.MoveTowards(transform.position, -transform.up*10, speed * Time.deltaTime);
                }
                else
                { // right side of the player
                    Debug.Log("Right");
                    transform.position = Vector2.MoveTowards(transform.position, -transform.right*10, speed * Time.deltaTime);
                    transform.position = Vector2.MoveTowards(transform.position, -transform.up*10, speed * Time.deltaTime);
                }
            }
        }
    }
}
