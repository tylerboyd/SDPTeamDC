using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

//Timothy Serrano: 1394556
//Andrew Bycroft: 16948980
//Larry Zhou:

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    Animator anim;
    public float speed;
    public Button m_attackButton;

    //The delay between attacking time, so animation is not spammed.
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    public AudioClip attackSound1;
    public AudioClip attackSound2;
    public AudioClip walkSound1;
    public AudioClip walkSound2;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Button attackButton = m_attackButton.GetComponent<Button>();
        attackButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //FOR JOYSTICK RUN THIS LINE (Must be on android build settings)
        Vector2 movement_vector = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));

        //FOR WASD RUN THIS LINE 
        //Vector2 movement_vector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

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
                SoundManager.Instance.RandomPlayWalkingSource(walkSound1, walkSound2);
            }

            rb2D.MovePosition(rb2D.position + movement_vector * Time.deltaTime * speed);

        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("isAttacking", false);

            //Space to attack
            if (Input.GetKeyDown(KeyCode.Space) && !attacking)
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rb2D.velocity = Vector2.zero;
                anim.SetBool("isAttacking", true);
                SoundManager.Instance.RandomPlayAttackSource(attackSound1, attackSound2);
                //THE CHANGES TO WORKING CODE

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyFollow>().TakeDamage(damage);
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

    //Function for attack button
    public void TaskOnClick()
    {
        attackTimeCounter = attackTime;
        attacking = true;
        rb2D.velocity = Vector2.zero;
        anim.SetBool("isAttacking", true);
        //THE CHANGES TO WORKING CODE

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyFollow>().TakeDamage(damage);
        }
    }
}