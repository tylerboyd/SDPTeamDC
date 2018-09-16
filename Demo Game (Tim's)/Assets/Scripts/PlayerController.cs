using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private Animator animate;

    protected Joystick joystick;
    protected Joybutton joybutton;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
//        joystick = FindObjectOfType<Joystick>();
//        joybutton = FindObjectOfType<Joybutton>();
    }

    //Always use GetAxisRaw otherwise object will slide
    //deltaTime to fix the amount of updates per elapsed time
    void FixedUpdate()
    {
        //rb2d.velocity = new Vector3(joystick.Horizontal * 5.0f,
         //   rb2d.velocity.y, joystick.Vertical * 5.0f);

            float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            float moveVertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.A)) 
            {
                animate.SetInteger("Direction", 1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                animate.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.D))
           {
                animate.SetInteger("Direction", 3);
           }

            if (Input.GetKey(KeyCode.S))
            {
                animate.SetInteger("Direction", 4);
            }

            transform.Translate(new Vector3(moveHorizontal, moveVertical));

            animate.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            animate.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }
}

