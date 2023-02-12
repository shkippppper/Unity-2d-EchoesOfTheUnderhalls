using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;
    private float timeSinceLastShot;
    private GameObject player;
    public float bulletSpeed = 1f;


    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");  // Get reference to the player's 
        }
    }


    void Update()
    {
        if (Time.time >= timeSinceLastShot + fireRate)
        {
            timeSinceLastShot = Time.time;

            Shoot();
        }


    }

    public void Shoot()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle - 90));
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

}
