using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    private Animator anim;

    void start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                   // enemiesToDamage[i].GetComponent
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
