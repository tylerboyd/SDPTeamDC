using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556
//Andrew Bycroft: 16948980

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    public float speed;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        //Sets the enemy to find the game object named "Hero" aka our character
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks how far the enemy is from the Hero. If it is close, change it to a kinematic rigidbody 
        //to stop it from moving the Hero and other enemies. This also stops the Hero from moving the enemies.
        //Otherwise move toward the Hero.
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
}
