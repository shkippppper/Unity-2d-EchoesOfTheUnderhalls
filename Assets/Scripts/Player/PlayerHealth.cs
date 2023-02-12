using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject deathEffect;  // Effect to play when the player dies


    public float health;  // Starting health of the player
    public float maxHealth;
    public bool isInvincible = false; // Check if player is invincilbe or not 
    public float invincibilityDuration = 0.5f;  // How long the player is invincible for 
    private float invincibilityTime;  // time when the player becomes invincible


    public TextMeshPro healthText;
    public TextMeshPro maxHealthText;
    public Color flashColor = new Color(1f, 1f, 1f, 0.5f);
    private Color originalColor;
    public GameManager gameManager;
    public Animator hitFlash;


    private void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = maxHealth;
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        
        health = Mathf.Clamp(health, 0, maxHealth);

        UpdatePlayerHealthUI();

        if (isInvincible)
        {
            spriteRenderer.color = flashColor;

            if (Time.time > invincibilityTime + invincibilityDuration)
            {
                spriteRenderer.color = originalColor;
                isInvincible = false;
            }
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }


    }



    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            if(damage == 757)
            {
                health -= 0;
                invincibilityTime = Time.time;
                isInvincible = true;
            }

            else
            {
                hitFlash.SetTrigger("TrHitFlash");
                health -= 1;
                invincibilityTime = Time.time;
                isInvincible = true;
            }



            if (health <= 0)
            {
                Die();
            }
        }
    }



    void Die()
    {
        // Play death effect
        GameObject death = Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(death, 0.5f);

        // Handle death
        gameManager.GameLose();
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }

    private void UpdatePlayerHealthUI()
    {
        healthText.text = health.ToString();
        maxHealthText.text = maxHealth.ToString();
    }

    

}
