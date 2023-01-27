using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyTeleport : MonoBehaviour
{

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootingRate = 1f;
    public float cooldown = 2f;
    private float nextShotTime;
    private float nextTpTime;

    private Transform player; //reference player

    public Transform[] teleportTransfroms;
    private int transformIterator;

    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's transform

        }
    }




    void Update()
    {
        //rotation
        Vector2 direction = (player.position - transform.position).normalized;

        // Check if the player is to the right of the enemy 
        if (direction.x > 0)
        {
            // Flip the enemy to face right
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Check if the player is to the left of the enemy
        else if (direction.x < 0)
        {
            // Flip the enemy to face left
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //shooting

        if (Time.time > nextShotTime)
        {
            // spawn bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // set bullet's velocity
            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
            // update the time for next shot
            nextShotTime = Time.time + cooldown;
        }

        if(Time.time > nextTpTime)
        {
            
            transform.position = teleportTransfroms[transformIterator].position;
            nextTpTime = Time.time + cooldown;
            transformIterator = Random.Range(0,3);
        }

    }
}
