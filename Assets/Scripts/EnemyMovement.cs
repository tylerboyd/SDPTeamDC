using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    public Rigidbody2D rb2d;
    public float speed;
    public Transform enemy;
    public Animator anim;
    public float xInput;

    // Use this for initialization
    void Start()
    {
        //Sets the enemy to find the game object named "Player" aka our character
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemy_coordinates = new Vector2(transform.position.x, transform.position.y);
        
        if (enemy_coordinates != Vector2.zero)
     // if(enemy.transform.position.x > 0.0f || enemy.transform.position.x < -0.0f || enemy.transform.position.y < -0.0f 
     //      || enemy.transform.position.y < -0.0f)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("MoveX", enemy_coordinates.x);
            anim.SetFloat("MoveY", enemy_coordinates.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("MoveX", enemy_coordinates.x);
            anim.SetFloat("MoveY", enemy_coordinates.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
