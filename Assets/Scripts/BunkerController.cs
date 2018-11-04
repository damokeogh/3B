using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerController : MonoBehaviour {

	private float zScaleModifier;

	// Use this for initialization
	void Start () {
		//get 10% of the objects current scale
		zScaleModifier = transform.localScale.z * 0.1f;
	}

	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("EnemyBullet")) {
			//get new size
			float newScaleZ = transform.localScale.z - zScaleModifier;
			if (newScaleZ > 0) {
				//apply new size
				transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, newScaleZ);
				//set position so object looks to be shrinking from the top down
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z / transform.localScale.z);
			} else {
				Destroy (this);
			}
		}
	}
}