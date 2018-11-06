using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {
    private float destroyTime;
    private float currentTime;

	// Use this for initialization
	void Start () {
        currentTime = Time.time;
        destroyTime = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > currentTime + destroyTime)
        {
            Destroy(this.gameObject);
        }
	}

}
