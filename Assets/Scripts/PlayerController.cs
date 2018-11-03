using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private int speed;
    private int xMin;
    private int xMax;
    private int zPos;
    private int yPos;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        speed = 15;
        xMin = -24;
        xMax = 24;
        yPos = 1;
        zPos = -11;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;
        rb.position = new Vector3 (Mathf.Clamp(rb.position.x, xMin, xMax), yPos, zPos);
		

    }
}
