using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLarry : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator anim;
    public AudioClip WalkSound1;
    public AudioClip WalkSound2;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("MoveX", movement_vector.x);
            anim.SetFloat("MoveY", movement_vector.y);
            SoundManager.Instance.RandomPlay(WalkSound1, WalkSound2);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        rb2D.MovePosition(rb2D.position + movement_vector * Time.deltaTime * 10);
    }
}
