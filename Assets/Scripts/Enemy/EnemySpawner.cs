using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    private GameObject player;

    public GameObject[] zeroEnemys;
    public GameObject[] oneEnemys;
    public GameObject[] twoEnemys;
    public GameObject[] threeEnemys;
    public GameObject[] fourEnemys;
    public GameObject[] fiveEnemys;
    public GameObject[] sixEnemys;
    public GameObject[] sevenEnemys;
    public GameObject[] eightEnemys;
    public List<GameObject[]> gameObjects = new();

    public int mode = 0;  //0-5lvl   - 0
                      //5-10lvl  - 1
                      //10-15lvl - 1 + 0
                      //15-20lvl - 2
                      //20-25lvl - 2 + 1
                      //25-30lvl - 3
                      //30-35lvl - 3 + 2
                      //35-40lvl - 4
                      //40-45lvl - 4 + 3
                      //45-50lvl - 5
                      //50-55lvl - 5 + 4
                      //60-65lvl - 6
                      //65-70lvl - 6 + 5
                      //75-80lvl - 7
                      //80-100lvl- 7 + 6 + 5 + 4

    public float spawnCooldown = 0.5f;
    private float nextShotTime;
    public int activeGameobjects = 0;
    public PlayerExperience playerExperience;


    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
        }
        activeGameobjects = FindObjectsOfType<GameObject>().Length;
    }



    void Update()
    {
        ModeCalculator();
        SpawnerCalculator();

        activeGameobjects = FindObjectsOfType<GameObject>().Length -40;

        if (Time.time > nextShotTime && activeGameobjects < 5000)
        {
            SpawnEnemies();

            nextShotTime = Time.time + spawnCooldown;
        }

        if(spawnCooldown > 0.1)
        {
            spawnCooldown -= Time.deltaTime * 0.001f;
        }

    }


    private void SpawnEnemies()
    {
        //float range = Random.Range(1.9f, 3f);
        float range = 1.9f;

        float randomRad = Random.Range(0f, 360f);
        float randomX = Mathf.Cos(randomRad) * range;
        float randomY = Mathf.Sin(randomRad) * range;

        Vector2 spawnLocation = player.transform.position + new Vector3(randomX, randomY, 0);

        GameObject[] gameObjectToSpawn = gameObjects[Random.Range(0, gameObjects.Count)];

        GameObject enemy = gameObjectToSpawn[Random.Range(0, gameObjectToSpawn.Length)];
        GameObject enemySpawned = Instantiate(enemy, spawnLocation, Quaternion.identity);
    }

    private void ModeCalculator()
    {
        mode = Mathf.FloorToInt(playerExperience.level / 5);
    }

    private void SpawnerCalculator()
    {
        switch (mode)
        {
            case 0:
                gameObjects.Add(zeroEnemys);  //0
                break;

            case 1:
                gameObjects.Add(oneEnemys);     //1
                gameObjects.Remove(zeroEnemys);
                break;

            case 2:
                gameObjects.Add(zeroEnemys);  //1+0
                break;

            case 3:
                gameObjects.Add(twoEnemys);       //2
                gameObjects.Remove(zeroEnemys);
                gameObjects.Remove(oneEnemys);
                break;

            case 4:
                gameObjects.Add(oneEnemys);      //2+1
                break;

            case 5:
                gameObjects.Add(threeEnemys);   //3
                gameObjects.Remove(oneEnemys);
                gameObjects.Remove(twoEnemys);
                break;

            case 6:
                gameObjects.Add(twoEnemys);     //3+2
                break;

            case 7:
                gameObjects.Add(fourEnemys);    //4
                gameObjects.Remove(twoEnemys);
                gameObjects.Remove(threeEnemys);
                break;

            case 8:
                gameObjects.Add(threeEnemys);    //4+3
                break;

            case 9:
                gameObjects.Add(fiveEnemys);    //5
                gameObjects.Remove(fourEnemys);
                gameObjects.Remove(threeEnemys);
                break;

            case 10:
                gameObjects.Add(fourEnemys);     //5+4
                break;

            case 11:
                gameObjects.Add(sixEnemys);       //6
                gameObjects.Remove(fiveEnemys);
                gameObjects.Remove(fourEnemys);
                break;

            case 12:
                gameObjects.Add(fiveEnemys);     //6+5
                break;

            case 13:
                gameObjects.Add(sevenEnemys);       //7
                gameObjects.Remove(sixEnemys);
                gameObjects.Remove(fiveEnemys);
                break;
            
            case 14:
                gameObjects.Add(eightEnemys);  
                gameObjects.Remove(sevenEnemys);   //8
                break;

            case 15:
                gameObjects.Add(sevenEnemys);     //8+7
                break;

            case 16:
                gameObjects.Add(sixEnemys);     //8+7+6+5+4+3+2+1+0
                gameObjects.Add(fiveEnemys);
                gameObjects.Add(fourEnemys);
                gameObjects.Add(threeEnemys);
                gameObjects.Add(twoEnemys);
                gameObjects.Add(oneEnemys);
                gameObjects.Add(zeroEnemys);
                break;

        }
    }
}
