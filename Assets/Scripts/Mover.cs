using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public Vector3 direction;

    private Rigidbody rb;
    private AudioSource shot;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody> ();
        shot = GetComponent<AudioSource>();
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