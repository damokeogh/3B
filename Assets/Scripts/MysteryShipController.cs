using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryShipController : MonoBehaviour {

	public int speed;
	public int xMax;
	public int timer;

	private Rigidbody rb;
	private float xStart;
	private float nextTime;
	private Vector3 velocity;
	private bool moving;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		xStart = transform.localPosition.x;
		velocity = new Vector3 (1.0f, 0.0f, 0.0f) * speed;
		Reset ();
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextTime) {
			if (moving) {
				//if off the screen reset
				if (transform.localPosition.x > xMax) {
					Reset ();
				}
			} else {
				//start moving
				Move ();
			}
		}
	}

	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("PlayerBullet")) {
			Reset ();
		}
	}

	public void Move () {
		rb.velocity = velocity;
		moving = true;
	}

	public void Reset () {
		//reset position, velocity and timer for next move across the screen
		nextTime = Time.time + timer;
		transform.localPosition = new Vector3 (xStart, transform.localPosition.y, transform.localPosition.z);
		rb.velocity = Vector3.zero;
		moving = false;
	}
}