using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerZone : MonoBehaviour {

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			for (int index = 0; index < transform.parent.childCount; index++) {
				GameObject gObject = transform.parent.GetChild (index).gameObject;
				if (gObject.CompareTag ("Bunker")) {
					Destroy (gObject);
				}
			}
		}
	}
}