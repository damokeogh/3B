using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZone : MonoBehaviour {

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			//end game & restart level
		}
	}
}
