using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Animator anim;
    public bool isMoving, playerMoving;
    public float xAxis, yAxis;
    public int speed;
    private Rigidbody2D rb;
    private GameObject target;
    private Vector2 lastMove;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Enemy");
        isMoving = false;
	}
	
	
	void FixedUpdate ()
    {
        isMoving = false;
        //get the x and y axis? if x and y of sprite is > 0, set isMoving to true
        //else false

     //   var moveVector = new Vector3(xAxis, yAxis, 0);

        //left and right
        if(target.transform.position.x > 0.0f || target.transform.position.x < -0.0f)
        {
            transform.Translate(new Vector3(target.transform.position.x * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(target.transform.position.x, 0f);
        }

        if (target.transform.position.y > 0.0f || target.transform.position.y < -0.0f)
        {
            transform.Translate(new Vector3(0f, target.transform.position.y * speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, target.transform.position.y);
        }

        anim.SetFloat("MoveX", target.transform.position.x);
        anim.SetFloat("MoveY", target.transform.position.y);
        anim.SetBool("isMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
       

        /*
        if(xAxis > 0.0f || yAxis > 0.0f)
        {
            anim.SetBool("isMoving", true);

        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (isMoving)
        {
            rb.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime),
                transform.position.y + moveVector.y * speed * Time.deltaTime));
        }
        */

        /*
        anim.SetFloat("xAxis", xAxis);
        anim.SetFloat("yAxis", yAxis);
        */
    }
}
