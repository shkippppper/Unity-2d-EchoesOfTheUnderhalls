using UnityEngine;

public class GodEnemy : MonoBehaviour
{
    // reference to the player
    private GameObject player;
    // bullet prefab
    public GameObject bulletPrefab;
    // bullet speed
    public float bulletSpeed = 10f;
    // shooting rate
    public float shootingRate = 1f;
    // time in seconds to wait between shots
    public float cooldown = 2f;
    private float nextShotTime;
    // radius of the circle
    public float radius = 5f;
    // speed of rotation
    public float rotationSpeed = 1f;
    // angle in degrees
    private float angle = 0f;

    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");  // Get reference to the player's transform

        }
    }

    void Update()
    {
        // calculate new angle
        angle += rotationSpeed * Time.deltaTime;
        // convert angle to radians
        float x = Mathf.Cos(angle + Random.Range(1, 10)) * radius;
        float y = Mathf.Sin(angle + Random.Range(1, 10)) * radius;
        // update position
        transform.position = new Vector3(x, y, transform.position.z);

        // check distance to player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // if distance is less than shooting distance and enough time has passed since last shot
        if (Time.time > nextShotTime)
        {
            // spawn bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // calculate direction towards player
            Vector3 direction = player.transform.position - transform.position;
            // set bullet's velocity
            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
            // update the time for next shot
            nextShotTime = Time.time + cooldown;
        }
    }
}
