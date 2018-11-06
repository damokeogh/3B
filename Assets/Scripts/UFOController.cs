using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour {

	public int timer;
    public int scoreValue;

    private GameController gameController;
    private float xStart;
	private float nextTime;
	private Mover mover;
	private bool moving;

	// Use this for initialization
	void Start () {
		xStart = transform.localPosition.x;
		mover = GetComponent<Mover>();
		Reset ();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        scoreValue = 150;
    }

	// Update is called once per frame
	void Update () {
		if (Time.time > nextTime) {
			if (!moving) {
				//start moving
				Move ();
			}
		}
	}

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("PlayerBullet")) {
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Reset(); 
            Debug.Log("collision");
            
            
        }
	}

	public void Move () {
		mover.Move();
		moving = true;
	}

	public void Reset () {
		//reset position, velocity and timer for next move across the screen
		nextTime = Time.time + timer;
		transform.localPosition = new Vector3 (xStart, transform.localPosition.y, transform.localPosition.z);
		mover.Stop();
		moving = false;
	}
}