using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;  // Enemy's movement speed
    private Transform player;  // Reference to the player's transform
    private Rigidbody2D rb;

    void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's transform

        }
        rb = GetComponent<Rigidbody2D>();
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


        if(Mathf.Abs(distance.x) + Mathf.Abs(distance.y) > 6)
        {
            Destroy(gameObject);
        }

        Vector2 direction = distance.normalized;
        
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


    }
}