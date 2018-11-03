using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerController : MonoBehaviour {

	private float zScaleModifier;

	// Use this for initialization
	void Start () {
		zScaleModifier = transform.localScale.z * 0.1f;
	}

	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("Enemy-bullet")) {
			float newScaleZ = transform.localScale.z - zScaleModifier;
			if (newScaleZ > 0) {
				transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, newScaleZ);
				transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - newScaleZ);
			} else {
				Destroy (this);
			}
		}
	}
}