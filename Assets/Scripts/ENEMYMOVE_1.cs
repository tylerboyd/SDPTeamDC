using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYMOVE_1 : MonoBehaviour {

    public Rigidbody2D rb2D;
    Animator anim;
    public float speed;
    private Transform target;
    public GameObject bloodSplash;

    public int health;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 1)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("MoveX", transform.position.x);
            anim.SetFloat("MoveY", transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("DamaGE TAKEN G");
    }
}
