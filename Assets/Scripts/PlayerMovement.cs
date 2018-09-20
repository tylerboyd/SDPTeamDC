using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    Animator anim;

    //The delay between attacking time, so animation is not spammed.
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (!attacking)
        {
            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("isWalking", true);
                /*
                 * These two lines of code update the float parameters for the animation,
                 * it is what is causing the player to NOT face in the direction after running
                 * but to face back to idle_down
                 * 
                */
                anim.SetFloat("MoveX", movement_vector.x);
                anim.SetFloat("MoveY", movement_vector.y);

                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            rb2D.MovePosition(rb2D.position + movement_vector * Time.deltaTime * 10);

        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("isAttacking", false);

            if (Input.GetKeyDown(KeyCode.Space) && !attacking)
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rb2D.velocity = Vector2.zero;
                anim.SetBool("isAttacking", true);
                /*THE CHANGES TO WORKING CODE*/

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<ENEMYMOVE_1>().TakeDamage(damage);
                }
            }
        }
        else if(attackTimeCounter > 0)
        {
            //timeBtwAttack from blackthornprod
            attackTimeCounter -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}