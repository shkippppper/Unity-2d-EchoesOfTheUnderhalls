using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{

    public BossMovement enemyMovement;
    public EnemyShooting enemyShooting;

    public GameObject bulletPrefab;
    public EnemyHealth bossHealth;
    public float bulletSpeed;
    private float timeSinceLastShot;
    private float fireRate = 3f;


    private List<int> unusedIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeSinceLastShot + fireRate)
        {
            timeSinceLastShot = Time.time;

            if (bossHealth.currentHealth / bossHealth.startingHealth < 0.35f)
            {
                BossPhaseThree();
            }

            else if (bossHealth.currentHealth / bossHealth.startingHealth < 0.65f)
            {
                BossPhaseTwo();
            }

            BossPhaseOne();
        }

    }



    public void BossPhaseOne()
    {
        enemyMovement.enabled = true;

        for (int i = 0; i < 8; i++)
        {
            int randomSide = Random.Range(0, 2);

            if(unusedIndexes.Count > 0)
            {
                int randomIndex = Random.Range(0, unusedIndexes.Count);
                int chosenIndex = unusedIndexes[randomIndex];
                if (randomSide == 0)
                {
                    GameObject arrow = Instantiate(bulletPrefab, new Vector3(19.15f + chosenIndex * 0.2f, 4.3f, 0), Quaternion.identity);
                    arrow.GetComponent<Rigidbody2D>().velocity = bulletSpeed * Vector3.up;

                } else if (randomSide == 1)
                {
                    GameObject arrow = Instantiate(bulletPrefab, new Vector3(19.15f + chosenIndex * 0.2f, 9f, 0), Quaternion.Euler(0,0,180));
                    arrow.GetComponent<Rigidbody2D>().velocity = bulletSpeed * Vector3.down;
                }
                unusedIndexes.RemoveAt(randomIndex);
            }
            else
            {
                break;
            }
        }
        unusedIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
    }

    private void BossPhaseTwo()
    {


        bossHealth.gameObject.transform.localScale = new Vector3 (Mathf.Lerp(1f, 1.1f, 2f), Mathf.Lerp(1f, 1.1f, 2f));
    }


    private void BossPhaseThree()
    {
        enemyMovement.speed = 0.3f;
        enemyShooting.enabled = true;

        bossHealth.gameObject.transform.localScale = new Vector3(Mathf.Lerp(1.1f, 1.2f, 2f), Mathf.Lerp(1.1f, 1.2f, 2f));
        
    }
}
