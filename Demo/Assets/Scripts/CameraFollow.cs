using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float camera_initial_speed = 10f;
    Camera myCamera;

	// Use this for initialization
	void Start () {
        myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        myCamera.orthographicSize = (Screen.height / 30f);
        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, camera_initial_speed) + new Vector3(0, 0, -10);
        }
	}
}
