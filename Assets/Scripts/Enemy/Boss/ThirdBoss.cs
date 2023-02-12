using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBoss : MonoBehaviour
{

    public BossMovement enemyMovement;
    public EnemyShooting enemyShooting;
    private GameObject player;
    public EnemyHealth bossHealth;
    private float timeSinceLastSpawn;
    private float timeSinceLastSpawnHard;
    private float spawnRate = 0.3f;
    private float spawnRateHard = 0.1f;
    public GameObject bulletPrefab;
    public GameObject otherBulletPrefab;

    private bool phaseOne = true;
    private bool phaseThree = false;

    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");  // Get reference to the player's 
        }
    }

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
            Shoot();
        }

        if (Time.time >= timeSinceLastSpawnHard + spawnRateHard && phaseThree)
        {
            timeSinceLastSpawnHard = Time.time;
            ShootRandom();
        }
    }



    public void BossPhaseOne()
    {
        enemyMovement.enabled = true;
        enemyShooting.enabled = true;

    }

    private void BossPhaseTwo()
    {
 
        bossHealth.gameObject.transform.localScale = new Vector3(Mathf.Lerp(1f, 1.1f, 2f), Mathf.Lerp(1f, 1.1f, 2f));
        transform.localPosition = new Vector3(20.6692f, 7f, 0f);
        enemyMovement.speed = 0f;
        enemyShooting.fireRate = 0.1f;

    }


    private void BossPhaseThree()
    {
        enemyMovement.speed = 0.4f;
        bossHealth.gameObject.transform.localScale = new Vector3(Mathf.Lerp(1.1f, 1.2f, 2f), Mathf.Lerp(1.1f, 1.2f, 2f));

        phaseThree = true;

    }


    public void Shoot()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle - 90));
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 2;
    }

    public void ShootRandom()
    {
        Vector2 direction = new Vector2 (Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
        GameObject bullet = Instantiate(otherBulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 1.5f;
    }

}
