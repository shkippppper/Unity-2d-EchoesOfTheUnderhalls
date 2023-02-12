using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : MonoBehaviour
{

    public BossMovement enemyMovement;
    public EnemyShooting enemyShooting;

    public EnemyHealth bossHealth;
    private float timeSinceLastSpawn;
    private float timeSinceLastSpawnHard;
    private float spawnRate = 2f;
    private float spawnRateHard = 1f;

    private bool phaseOne = true;
    private bool phaseThree = false;
    public List<GameObject> enemys1;
    public List<GameObject> enemys2;


    // Update is called once per frame
    void Update()
    {



        BossPhaseOne();

        if (bossHealth.currentHealth / bossHealth.startingHealth < 0.35f)
        {
            BossPhaseThree();
        }
        
        if (bossHealth.currentHealth / bossHealth.startingHealth < 0.65f)
        {
            BossPhaseTwo();
        }

        if (Time.time >= timeSinceLastSpawn + spawnRate && phaseOne)
        {
            timeSinceLastSpawn = Time.time;
            SpawnEnemy1();
        }

        if (Time.time >= timeSinceLastSpawnHard + spawnRateHard && phaseThree)
        {
            timeSinceLastSpawnHard = Time.time;
            SpawnEnemy2();
        }
    }



    public void BossPhaseOne()
    {
        enemyMovement.enabled = true;
        enemyShooting.enabled = true;

    }

    private void BossPhaseTwo()
    {
        spawnRate = 1.4f;
        bossHealth.gameObject.transform.localScale = new Vector3(Mathf.Lerp(1f, 1.1f, 2f), Mathf.Lerp(1f, 1.1f, 2f));
        enemyMovement.speed = 0.3f;
        enemyShooting.fireRate = 0.2f;
    }


    private void BossPhaseThree()
    {
        enemyMovement.speed = 0.4f;
        bossHealth.gameObject.transform.localScale = new Vector3(Mathf.Lerp(1.1f, 1.2f, 2f), Mathf.Lerp(1.1f, 1.2f, 2f));

        phaseThree = true;

    }

    public void SpawnEnemy1()
    {
        int randomEnemy = Random.Range(0, enemys1.Count);
        Instantiate(enemys1[randomEnemy], new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, 0), Quaternion.identity);
    }

    public void SpawnEnemy2()
    {
        int randomEnemy = Random.Range(0, enemys2.Count);
        Instantiate(enemys2[randomEnemy], new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, 0), Quaternion.identity);
    }
}
