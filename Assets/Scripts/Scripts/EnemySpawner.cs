using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;
    public GameObject[] enemys;
    public float spawnCooldown = 1f;
    private float nextShotTime;



    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
        }
    
    }

    void Start()
    {
        
    }

    void Update()
    {


        if (Time.time > nextShotTime)
        {
            float range = Random.Range(1.9f, 3f);

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);

            GameObject enemy = enemys[Random.Range(0, 2)];
            // spawn enemy
            GameObject enemySpawned = Instantiate(enemy, spawnLocation, Quaternion.identity);
            // update the time for next shot
            nextShotTime = Time.time + spawnCooldown;

            
        }
    }
}
