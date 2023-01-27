using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject[] characterBulletsPrefabs;
    public GameObject bulletPrefab;  // Prefab of the bullet object
    public float fireRate;  // Time between shots
    public float bulletDamageMin;
    public float bulletDamageMax;
    private float timeSinceLastShot;  // Time since last shot
    public float critChance;
    public float critDamage;
    private float finalDamage;

    public GameObject[] characterSpecialAttackPrefabs;
    public GameObject specialAttackPrefab;
    public float fireRateSpecial;
    public float specialDamage;
    private float timeSinceLastSpecial;

    //upgrades
    public bool attackPierces = false;
    public bool shootTheOpposite = false;
    public bool attacksHaveChanceForSpecial = false;
    public bool shortRange = false;
    public bool specialsHaveChanceForAttack = false;
    public bool doubleShot = false;
    public bool tripleShot = false;

    

    void Update()
    {
        //set the bullet prefab to match the character
        bulletPrefab = characterBulletsPrefabs[0];
        specialAttackPrefab = characterSpecialAttackPrefabs[0]; 

        // Get the position of the mouse on the screen
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the player pressed the fire button
        if (Input.GetButton("Fire1"))
        {
            // Check if enough time has passed since the last shot
            if (Time.time >= timeSinceLastShot + fireRate)
            {
                timeSinceLastShot = Time.time;  // Update time since last shot

                Attack(mousePosition, bulletPrefab); // Fire at the mouse poisiton


                //if shootTheOpposite is true shoot the opposite side too
                if (shootTheOpposite)
                {
                    AttackOpposite(mousePosition, bulletPrefab);
                }

                //10% chance to create a specialattack after shooting
                if (attacksHaveChanceForSpecial)
                {
                    if (Random.Range(0, 100) < 10)
                    {
                        SpecialAttack(mousePosition, specialAttackPrefab);
                    }
                }

                if (tripleShot)
                {
                    Invoke("FireAnother", 0.03f);
                    Invoke("FireAnother", 0.06f);

                }

                if (doubleShot)
                {
                    Invoke("FireAnother", 0.05f);
                }



            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (Time.time >= timeSinceLastSpecial + fireRateSpecial)
            {
                timeSinceLastSpecial = Time.time;  // Update time since last shot

                SpecialAttack(mousePosition, specialAttackPrefab);

                if (specialsHaveChanceForAttack)
                {
                    if(Random.Range(0, 100) < 80)
                    {
                        Attack(mousePosition, bulletPrefab);
                    }

                }

            }
        }


    }

    public void Attack(Vector2 mousePosition, GameObject bulletPrefab)
    {

        // Instantiate a bullet object at the player's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Critical shot or not
        finalDamage = FinalDamage();

        // Give bullet the upgrade bool features
        bullet.GetComponent<Bullet>().finalDamage = finalDamage;
        bullet.GetComponent<Bullet>().attackPierces = attackPierces;
        bullet.GetComponent<Bullet>().shortRange = shortRange;

        // Set the bullet's direction to point towards the mouse position
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet.GetComponent<Bullet>().speed;

        //TripleAttack(mousePosition, bulletPrefab);
    }

    public void AttackOpposite(Vector2 mousePosition, GameObject bulletPrefab)
    {
        // Instantiate a bullet object at the player's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        finalDamage = FinalDamage();

        // Give bullet the upgrade bool features
        bullet.GetComponent<Bullet>().finalDamage = finalDamage;
        bullet.GetComponent<Bullet>().attackPierces = attackPierces;
        bullet.GetComponent<Bullet>().shortRange = shortRange;

        // Set the bullet's direction to opposite of the mouse position
        Vector2 directionBack = (mousePosition - (Vector2)transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = - directionBack * bullet.GetComponent<Bullet>().speed;
    
    }

    public void SpecialAttack(Vector2 mousePosition, GameObject specialAttackPrefab)
    {        
        // Instantiate a special attack object at the mouse position
        GameObject bullet = Instantiate(specialAttackPrefab, mousePosition, Quaternion.identity);
        bullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;
    }

    public float FinalDamage()
    {
        if (Random.Range(0, 100) < critChance)
        {
            float fnDamage = Mathf.RoundToInt(bulletDamageMax + bulletDamageMax * critDamage / 100);
            return fnDamage;
        }
        else
        {
            float fnDamage = Mathf.RoundToInt(Random.Range(bulletDamageMin, bulletDamageMax));
            return fnDamage;
        }
    }
    public void FireAnother()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Attack(mousePosition, bulletPrefab);
    }

    public void DashCreatesSpecial(Vector3 position)
    {
        GameObject bullet = Instantiate(specialAttackPrefab, position, Quaternion.identity);
        bullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;
    }
    
}
