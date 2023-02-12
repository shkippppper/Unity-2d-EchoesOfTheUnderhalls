using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 2f;  // Time before the bullet is destroyed
    private float spawnTime;  // Time the bullet was spawned
    public float damageMin = 7f;
    public float damageMax = 12f;
    private float finalDamage;

    void Start()
    {
        spawnTime = Time.time;

        finalDamage = (int)Random.Range(damageMin, damageMax);
    }

    void Update()
    {
        // Check if enough time has passed since the bullet was spawned
        if (Time.time >= spawnTime + lifetime)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collided with something
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(finalDamage);
            }
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}