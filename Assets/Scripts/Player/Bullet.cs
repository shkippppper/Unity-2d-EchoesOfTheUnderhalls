using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;  // Time before the bullet is destroyed
    private float spawnTime;  // Time the bullet was spawned
    public float finalDamage;
    public bool attackPierces = false;
    public bool shortRange = false;

    void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        if (shortRange)
        {
            lifetime = 0.3f;
        }
        // Check if enough time has passed since the bullet was spawned
        if (Time.time >= spawnTime + lifetime)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collided with something
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(finalDamage);
            }

            if (!attackPierces)
            {
                Destroy(gameObject);
            }
        }
    }
}