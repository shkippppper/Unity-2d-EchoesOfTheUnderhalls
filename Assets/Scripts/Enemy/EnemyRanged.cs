using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingRange = 5f;
    public float shootingInterval = 1f;
    private Transform player;

    private float timeSinceLastShot;

    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's transform

        }
    }
    void Update()
    {
        transform.LookAt(player);

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < shootingRange)
        {
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                timeSinceLastShot = 0;
            }
        }
    }
}