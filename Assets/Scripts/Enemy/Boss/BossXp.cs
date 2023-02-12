using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossXp : MonoBehaviour
{
    public float moveSpeed = 1f;  // Movement speed of the health pickup
    public float distanceThreshold = 0.2f;  // Distance at which the pickup starts moving towards the player
    public int XP;
    private Transform player;  // Reference to the player's transform
    private GameObject bossHp;
    private BossHp bossHpScript;
    private bool isMoving = false; // a flag to check if the health pick up is moving



    void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;  // Get reference to the player's 
        }

        if (GameObject.FindWithTag("BossHp") != null)
        {
            bossHp = GameObject.FindWithTag("BossHp");  // Get reference to the player's 
            bossHpScript = bossHp.GetComponent<BossHp>();
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
            PlayerExperience playerExperience = other.GetComponent<PlayerExperience>();

            if(playerExperience.level == 19)
            {
                XP = 2500;
            }
            else if (playerExperience.level == 39)
            {
                XP = 9400;
            }
            else if (playerExperience.level == 59)
            {
                XP = 27800;
            }
            else if (playerExperience.level == 79)
            {
                XP = 76900;
            }




            playerExperience.GainExperienceFlatRate(XP);
            // Destroy
            Destroy(this.gameObject);

            bossHpScript.EndBossFight();
        }
    }
}
