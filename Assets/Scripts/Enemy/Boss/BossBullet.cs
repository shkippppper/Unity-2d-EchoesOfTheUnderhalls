using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 1f;
    public float lifetime = 5f;  // Time before the bullet is destroyed
    private float spawnTime;  // Time the bullet was spawned



    void Start()
    {
        spawnTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime + lifetime)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
