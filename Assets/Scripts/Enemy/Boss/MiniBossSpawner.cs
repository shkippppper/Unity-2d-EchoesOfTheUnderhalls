using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSpawner : MonoBehaviour
{

    private PlayerExperience playerExperience;
    private GameObject player;
    public List<bool> canSpawn;
    public List<int> levelsToSpawnOn;


    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
            playerExperience = player.GetComponent<PlayerExperience>();
        }
    }


    public List<GameObject> Bosses;

    // Update is called once per frame
    void Update()
    {
        if(playerExperience.level == levelsToSpawnOn[0] && canSpawn[0])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[0], spawnLocation, Quaternion.identity);
            canSpawn[0] = false;

        }

        else if (playerExperience.level == levelsToSpawnOn[1] && canSpawn[1])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[1], spawnLocation, Quaternion.identity);
            canSpawn[1] = false;

        }
        else if (playerExperience.level == levelsToSpawnOn[2] && canSpawn[2])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[2], spawnLocation, Quaternion.identity);
            canSpawn[2] = false;

        }
        else if (playerExperience.level == levelsToSpawnOn[3] && canSpawn[3])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[3], spawnLocation, Quaternion.identity);
            canSpawn[3] = false;

        }
        else if (playerExperience.level == levelsToSpawnOn[4] && canSpawn[4])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[4], spawnLocation, Quaternion.identity);
            canSpawn[4] = false;

        }
        else if (playerExperience.level == levelsToSpawnOn[5] && canSpawn[5])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[5], spawnLocation, Quaternion.identity);
            canSpawn[5] = false;

        }
        else if (playerExperience.level == levelsToSpawnOn[6] && canSpawn[6])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[6], spawnLocation, Quaternion.identity);
            canSpawn[6] = false;

        }
        else if (playerExperience.level == levelsToSpawnOn[7] && canSpawn[7])
        {
            float range = 1.9f;

            float randomRad = Random.Range(0f, 360f);
            float randomX = Mathf.Cos(randomRad) * range;
            float randomY = Mathf.Sin(randomRad) * range;

            Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);
            GameObject enemySpawned = Instantiate(Bosses[7], spawnLocation, Quaternion.identity);
            canSpawn[7] = false;

        }




    }
}
