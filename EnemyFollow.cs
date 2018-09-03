using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556
//Andrew Bycroft: 16948980

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        //Sets the enemy to find the game object named "Hero" aka our character
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Moves the enemies position towards the target("Hero") against a fixed speed
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
