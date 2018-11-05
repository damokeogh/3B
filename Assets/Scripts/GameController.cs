using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text lifeText;
    public GameObject player;
    public GameObject enemies;

    private int score;
    private int lives;
    private bool playerDead;
    private float currentTime;
    private float respawnDelay;
    private GameObject currentEnemies;
    private bool enemySpawned;


	// Use this for initialization
	void Start () {
        score = 0;
        lives = 3;
        playerDead = false;
        enemySpawned = true;
        respawnDelay = 3;
        currentEnemies = GameObject.FindWithTag("EnemyPrefab");
      
    }
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
        UpdateLives();
        if(playerDead == true  && lives != 0 && Time.time > currentTime + respawnDelay)
        {
            Instantiate(player);
            Instantiate(enemies);
            currentEnemies = GameObject.FindWithTag("EnemyPrefab");
            playerDead = false;
            enemySpawned = true;
        }
        else if (playerDead == true && lives == 0 && Time.time > currentTime + respawnDelay)
        {
            Application.LoadLevel(Application.loadedLevel);

        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;

    }

    public void RemoveLife(int newLifeValue)
    {
        lives += newLifeValue;
        playerDead = true;
        currentTime = Time.time;
        Destroy(currentEnemies.gameObject);
        enemySpawned = false;

    }


    void UpdateLives()
    {
        lifeText.text = "Lives: " + lives;

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;

    }
}
