using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556

public class PlayerMovement : MonoBehaviour {

    private float theSpeed;

    /*The if statements read keyboard input, which are then translated to
     * the characters movements
     * 
     * Vector2 for X and Y coordinates
    */
    void Update () {

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * theSpeed);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * theSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * theSpeed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * theSpeed);
        }
    }

    public void SetSpeed(float theSpeed)
    {
        this.theSpeed = theSpeed;
    }
   
}
