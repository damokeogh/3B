using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public Vector3 direction;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody> ();
        if (!transform.CompareTag ("UFO")){
            Move();
        }
    }

    public void Move () {
        rb.velocity = direction * speed;
    }

    public void Stop(){
        rb.velocity = Vector3.zero;
    }

}