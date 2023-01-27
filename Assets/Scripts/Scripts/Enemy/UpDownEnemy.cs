using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownEnemy : MonoBehaviour
{

    [Header("Movement")]
    public Transform upTransform;       //preset location up
    public Transform downTransform;   //preset location down
    public float speed = 0.8f;     //speed at which the GO moves from one location to another
    public bool goingUp = true;   //boolean to track the movement vector of the GO

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootingRate = 1f;
    public float cooldown = 2f;
    private float nextShotTime;

    private Transform player; //reference player
    private Rigidbody2D rb;  //reference GO rigidbody to move and rotate

    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's transform

        }
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        //get directions to up and down transfrom objects
        Vector2 upDirection = (upTransform.position - transform.position).normalized;
        Vector2 downDirection = (downTransform.position - transform.position).normalized;


        // check if the player is going up
        if (goingUp)
        {
            // if so move the player to the upper gameobjects transform location
            rb.MovePosition(rb.position + upDirection * speed * Time.deltaTime);

            // when the destination is reached make the goingup variable false to go down
            if (upDirection.y < 0)
            {
                goingUp = false;
            }
        }
        // check if the player is going down
        else
        {
            // if so move the player to the down gameobjects transform location
            rb.MovePosition(rb.position + downDirection * speed * Time.deltaTime);

            // when the destination is reached make the goingup variable true to go up
            if (downDirection.y > 0)
            {
                goingUp = true;
            }
        }
    }

    private void Update()
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
            //// calculate direction towards player
            //direction = player.transform.position - transform.position;
            // set bullet's velocity
            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
            // update the time for next shot
            nextShotTime = Time.time + cooldown;
        }
    }



}
