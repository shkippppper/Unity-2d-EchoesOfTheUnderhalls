using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float moveSpeed = 1f;  // Movement speed of the health pickup
    public float distanceThreshold = 1f;  // Distance at which the pickup starts moving towards the player
    public float healthPickup = 10f;
    private Transform player;  // Reference to the player's transform
    private bool isMoving = false; // a flag to check if the health pick up is moving
    

    void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's 
        }
    }

    void Update()
    {
        // Check if the player is within the distance threshold
        if (Vector2.Distance(transform.position, player.position) <= distanceThreshold)
        {
            isMoving = true;
        }
        if (isMoving)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the pickup
        if (other.CompareTag("Player"))
        {
            // Add health to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.health += healthPickup;

            // Destroy
            Destroy(this.gameObject);
        }
    }
}

