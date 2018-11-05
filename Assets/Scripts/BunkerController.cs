using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerController : MonoBehaviour {

	private float zScaleModifier;

    public GameObject explode;

	// Use this for initialization
	void Start () {
		//get 10% of the objects current scale
		zScaleModifier = transform.localScale.z * 0.1f;
	}

	private void OnTriggerEnter (Collider other) {
        //get new size
        float newScaleZ = transform.localScale.z - zScaleModifier;
		if (newScaleZ > 0) {
			//apply new size
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, newScaleZ);
            Destroy(other.gameObject);
        } else {
            Destroy (this.gameObject);
            
        }
        Destroy(other.gameObject);
        GameObject clone = Instantiate(explode);
    }
}