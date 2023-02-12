using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject[] characterBulletsPrefabs;
    public GameObject bulletPrefab;  // Prefab of the bullet object
    public PlayerHealth playerHealth;
    public float fireRate;  // Time between shots
    public float bulletDamageMin;
    public float bulletDamageMax;
    public float critChance;
    public float critDamage;
    private float finalDamage;

    public GameObject[] characterSpecialAttackPrefabs;
    public GameObject specialAttackPrefab;
    public float fireRateSpecial;
    public float specialDamage;
    public float timeSinceLastSpecial;

    //upgrades
    public bool attackPierces = false;
    public bool shootTheOpposite = false;
    public bool attacksHaveChanceForSpecial = false;
    public bool shortRange = false;
    public bool specialsHaveChanceForAttack = false;
    public bool doubleShot = false;
    public bool tripleShot = false;

    public float timeSinceLastShot;  // Time since last shot
    public Characters characters;

    void Update()
    {

        int characterIndex = characters.characterIndex;
        //set the bullet prefab to match the character
        bulletPrefab = characterBulletsPrefabs[characterIndex];
        specialAttackPrefab = characterSpecialAttackPrefabs[characterIndex];
        

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
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Instantiate a bullet object at the player's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,angle-90));

        // Critical shot or not
        finalDamage = FinalDamage();

        // Give bullet the upgrade bool features
        bullet.GetComponent<Bullet>().finalDamage = finalDamage;
        bullet.GetComponent<Bullet>().attackPierces = attackPierces;
        bullet.GetComponent<Bullet>().shortRange = shortRange;

        // Set the bullet's direction to point towards the mouse position
        
        
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
        if(characters.characterIndex == 0)
        {

            GameObject bullet = Instantiate(specialAttackPrefab, mousePosition, Quaternion.identity);
            bullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;
        }
        else if(characters.characterIndex == 1)
        {
            GameObject bullet = Instantiate(specialAttackPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;

        }
        else if(characters.characterIndex == 2)
        {
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(specialAttackPrefab, transform.position, Quaternion.Euler(0, 0, angle - 90));
            bullet.GetComponent<Bullet>().finalDamage = finalDamage;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet.GetComponent<Bullet>().speed;


        }
        else if (characters.characterIndex == 3)
        {
            GameObject bullet = Instantiate(specialAttackPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;
            playerHealth.TakeDamage(757);
            Invoke(nameof(PlayerTakesNoDamageForInvulnerability), 0.5f);
        }
        else if (characters.characterIndex == 4)
        {
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            GameObject bullet = Instantiate(specialAttackPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().finalDamage = finalDamage;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet.GetComponent<Bullet>().speed;
        }
        else if (characters.characterIndex == 5)
        {
            GameObject bullet = Instantiate(specialAttackPrefab, mousePosition, Quaternion.identity);
            bullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;
        }
        else { }


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
    
    public void PlayerTakesNoDamageForInvulnerability()
    {        
        playerHealth.TakeDamage(757);
        Invoke(nameof(PlayerCreatesSecondPortal), 0.4f);

    }
    public void PlayerCreatesSecondPortal()
    {
        GameObject endBullet = Instantiate(specialAttackPrefab, transform.position, Quaternion.identity);
        endBullet.GetComponent<SpecialPyro>().finalDamage = specialDamage;
    }

}
