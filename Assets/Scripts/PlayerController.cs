using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private int speed;
    private int xMin;
    private int xMax;
    private int zPos;
    private int yPos;
    private float nextFire;
    private float fireRate;


    public Transform shotSpawn;
    public GameObject bullet;


	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        speed = 15;
        xMin = -24;
        xMax = 24;
        yPos = 1;
        zPos = -11;
        nextFire = 0.0f;
        fireRate = 0.25f;

	}

    private void Update()
    {
        if (Input.GetButton("Fire1") &&  Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }
        


    }

    void FixedUpdate ()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;
        rb.position = new Vector3 (Mathf.Clamp(rb.position.x, xMin, xMax), yPos, zPos);
		

    }
}
