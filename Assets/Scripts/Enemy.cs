﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);		
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("DamaGE TAKEN BRUHHHHHHHHHH -1 HEALTH");
    }
}
