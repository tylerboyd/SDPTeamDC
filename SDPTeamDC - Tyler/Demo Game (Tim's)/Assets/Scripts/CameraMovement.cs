using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Serrano: 1394556

public class CameraMovement : MonoBehaviour {

    Transform target;

	// Use this for initialization
	void Start () {

        //The camera targets "Hero" GameObject
        target = GameObject.Find("Hero").transform;

	}
	
	// Update is called once per frame
	void Update () {
        //the cameras coordinates are updated to the target's (hero_7) position
        transform.position = target.position + new Vector3(0,0,-10);
	}
}
