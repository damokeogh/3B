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
    private int lifeValue;

    private GameController gameController;
    public Transform shotSpawn;
    public GameObject bullet;
    public GameObject explode;


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
        lifeValue = -1;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject clone = Instantiate(explode);
            gameController.RemoveLife(lifeValue);

        }
        if (other.gameObject.CompareTag("UFO"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject clone = Instantiate(explode);
            gameController.RemoveLife(lifeValue);

        }
    }
}
