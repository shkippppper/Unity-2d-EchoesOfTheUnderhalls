using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 1f;  // Enemy's movement speed
    private Transform player;  // Reference to the player's transform
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's transform

        }
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        // Get the direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void Update()
    {
        Vector2 distance = player.position - transform.position;


        Vector2 direction = distance.normalized;

        // Check if the player is to the right of the enemy
        if (direction.x > 0)
        {
            // Flip the enemy to face right
            spriteRenderer.flipX = false;
        }
        // Check if the player is to the left of the enemy
        else if (direction.x < 0)
        {
            // Flip the enemy to face left
            spriteRenderer.flipX = true;

        }


    }
}