using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour {

    Rigidbody2D rb2D;
    Animator anim;

    // Use this for initialization
    void Start () {

        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("MoveUp", true);
            anim.SetBool("MoveDown", false);
            anim.SetBool("MoveRight", false);
            anim.SetBool("MoveLeft", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", true);
            anim.SetBool("MoveRight", false);
            anim.SetBool("MoveLeft", false);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveRight", true);
            anim.SetBool("MoveLeft", false);
            anim.SetBool("MoveDown", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveRight", false);
            anim.SetBool("MoveLeft", true);
            anim.SetBool("MoveDown", false);
        }
    }
}
