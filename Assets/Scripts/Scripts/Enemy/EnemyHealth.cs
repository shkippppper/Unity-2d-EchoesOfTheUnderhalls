using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;  // Starting health of the enemy
    public float currentHealth;  // Current health of the enemy
    public GameObject deathEffect;  // Effect to play when the enemy dies
    public GameObject damagePopupPrefab;
    public GameObject xpPickup;
    public GameObject hpPickup;
    public int hpPickupDropChance = 10;

    public int coinPickupDropChance = 40;
    public GameObject oneCoin;
    public GameObject twoCoin;
    public GameObject threeCoin;
    public GameObject fourCoin;
    public GameObject fiveCoin;


    private GameObject upgradesManager;
    private Stats stats;
    private DamageFlash2D damageFlash2D;

    private void Awake()
    {
        damageFlash2D = gameObject.GetComponent<DamageFlash2D>();
        if(GameObject.FindWithTag("Player") != null)
        {
            upgradesManager = GameObject.FindWithTag("UpgradesManager");
            stats = upgradesManager.GetComponent<Stats>();
        }

    }

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        damageFlash2D.TakeDamage();
        currentHealth -= damage;
        GameObject damagePopup = Instantiate(damagePopupPrefab);
        damagePopup.GetComponent<DamagePopup>().setDamage(damage, this.transform);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death effect
        GameObject death =  Instantiate(deathEffect, transform.position, transform.rotation);

        // Spawn the xp pickup 
        Instantiate(xpPickup, transform.position, transform.rotation);

        // spawn the hp pickup on chance
        if(Random.Range(0,100) < hpPickupDropChance)
        {
            Instantiate(hpPickup, transform.position + new Vector3(0, 0.05f, 0), transform.rotation);
        }

        if (stats.midas)
        {
            SpawnCoin();
        }
        else
        {
            if(Random.Range(0,100) < coinPickupDropChance)
            {
                SpawnCoin();
            }
        }



        // Destroy the enemy
        Destroy(gameObject);

        // Destroy the effect
        Destroy(death, 0.2f);
    }

    public void SpawnCoin()
    {
        int twoCoinChance = 40;
        int threeCoinChance = 30;
        int fourCoinChance = 15;
        int fiveCoinChance = 5;

        int random = Random.Range(0, 100);


        if (random < fiveCoinChance)
        {
            Instantiate(fiveCoin, transform.position - new Vector3(0, 0.05f, 0), transform.rotation);
        }
        else if (random < fourCoinChance)
        {
            Instantiate(fourCoin, transform.position - new Vector3(0, 0.05f, 0), transform.rotation);

        }
        else if (random < threeCoinChance)
        {
            Instantiate(threeCoin, transform.position - new Vector3(0, 0.05f, 0), transform.rotation);

        }
        else if (random < twoCoinChance)
        {
            Instantiate(twoCoin, transform.position - new Vector3(0, 0.05f, 0), transform.rotation);

        }
        else
        {
            Instantiate(oneCoin, transform.position - new Vector3(0, 0.05f, 0), transform.rotation);

        }

    }
}
