using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private int speed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        speed = 20;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);

	}
	
	
}
