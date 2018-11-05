using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirectionController : MonoBehaviour {

	private bool changed;
	private float timeChanged;

	private void FixedUpdate () {
		if (Time.time > timeChanged + 2) {
			changed = false;
		}
	}

	public void ChangeDirection () {
		if (!changed) {
			//change direction
			Vector3 direction = GetComponent<Mover> ().direction * -1;
			float speed = GetComponent<Mover> ().speed;
			GetComponent<Mover> ().speed = Mathf.Clamp (speed + 1, 5, 9.5f);
			GetComponent<Mover> ().direction = direction;
			GetComponent<Mover> ().Move ();
			//move down
			transform.localPosition = new Vector3 (transform.localPosition.x,
				transform.localPosition.y,
				transform.localPosition.z - 0.5f);
			changed = true;
			timeChanged = Time.time;
		}
	}
}