using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator anim;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("MoveX", movement_vector.x);
            anim.SetFloat("MoveY", movement_vector.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        //rb2D.MovePosition(rb2D.position + movement_vector * Time.deltaTime * 10);

        transform.Translate(new Vector3(moveHorizontal, moveVertical));

    }
}