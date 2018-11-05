using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
		public GameObject shot;
		public Transform shotSpawn;
		public float fireRate;
		public float startWait;

		private Vector3 downDir;
		private bool canFire;
		private float nextFire;

		private void Start () {
			downDir = new Vector3 (0, 0, -1);
			nextFire = Time.time + startWait;
		}

		void Update () {
			if (canFire && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
		}

		private void FixedUpdate () {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, downDir, out hit, 10)) {
				GameObject hitObject = hit.transform.gameObject;
				//Debug.Log ("Target found " + hitObject.tag);
				if (hitObject.CompareTag ("BunkerZone")) {
					//Debug.Log ("Target found");
					canFire = true;
				}
			} else {
				canFire = false;
			}
		}

		private void OnTriggerEnter (Collider other) {
			if (other.gameObject.CompareTag ("Boundary")) {
				return;
			} else if (other.gameObject.CompareTag ("PlayFieldBorder")) {
				transform.parent.GetComponent<EnemyDirectionController> ().ChangeDirection ();
			} else if (other.gameObject.CompareTag ("PlayerBullet")) {
					Destroy (this.gameObject);
					Destroy (other.gameObject);
				}
			}
		}