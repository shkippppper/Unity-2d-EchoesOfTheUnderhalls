using UnityEngine;

public class SpecialPyro : MonoBehaviour
{
    public float lifetime = 0.5f;  // Time before the bullet is destroyed
    private float spawnTime;  // Time the bullet was spawned
    public float finalDamage;
    public bool bulletPierces;
    public bool heals;

    void Start()
    {
        spawnTime = Time.time;
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

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(finalDamage);
            //Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player")  && heals)
        {
            collision.GetComponent<PlayerHealth>().RestoreHealth(1);
            Destroy(gameObject);
        }
    }
}
