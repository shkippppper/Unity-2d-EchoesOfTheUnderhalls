using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [Header("Stats")]
    public float minDamage;  //1
    public float maxDamage;  //1
    public float specialAttackDamage; //2
    public float specialAttackCooldown;
    public float attackSpeed;  //3
    public float criticalChance; //4
    public float criticalDamage; //5
    public float dashRange;
    public float dashCooldown;
    public float hitInvulnerability;
    public float maxHealth; //6
    public float moveSpeed; //7

    public bool attackPierces = false;
    public bool shootTheOpposite = false;
    public bool attacksHaveChanceForSpecial = false;
    public bool specialsHaveChanceForAttack = false;
    public bool midas = false;
    public bool doubleXp = false;
    public bool doubleGold = false;
    public bool dashCreatesSpecialOnStart = false;
    public bool dashCreatesSpecialOnEnd = false;
    public bool tripleShot = false;
    public bool doubleShot = false;
    public bool shortRange = false;


    public int rerolls;

    [Header("TextReferences")]
    public TextMeshProUGUI attackDmgText;
    public TextMeshProUGUI specialAttackText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI criticalChanceText;
    public TextMeshProUGUI criticalDamageText;
    public TextMeshProUGUI moveSpeedText;
    public TextMeshProUGUI maxHealthText;

    [Header("ScriptReferences")]
    public PlayerHealth playerHealth;
    public PlayerShooting playerShooting;
    public PlayerStartingStats playerStartingStats;
    public PlayerMovement playerMovement;
    public RerollScript rerollScript;
    public PlayerGold playerGold;
    public PlayerExperience playerExperience;


    private void Start()
    {
        playerStartingStats.UpdateStats();
        rerolls = rerollScript.rerolls;

    }

    private void Update()
    {
        UpdateUGUI();
        UpdateStats();
    }

    private void UpdateStats()
    {
        //floats and ints
        playerShooting.bulletDamageMin = minDamage;
        playerShooting.bulletDamageMax = maxDamage;
        playerShooting.specialDamage = specialAttackDamage;
        playerShooting.fireRateSpecial = specialAttackCooldown;
        playerShooting.fireRate = attackSpeed;
        playerShooting.critChance = criticalChance;
        playerShooting.critDamage = criticalDamage;
        playerMovement.dashSpeed = dashRange;
        playerMovement.dashCooldown = dashCooldown;
        playerHealth.invincibilityDuration = hitInvulnerability;
        playerHealth.maxHealth = maxHealth;
        playerMovement.moveSpeed = moveSpeed;
        rerollScript.rerolls = rerolls;

        //bools
        playerShooting.attackPierces = attackPierces;
        playerShooting.shootTheOpposite = shootTheOpposite;
        playerShooting.attacksHaveChanceForSpecial = attacksHaveChanceForSpecial;
        playerShooting.specialsHaveChanceForAttack = specialsHaveChanceForAttack;
        playerGold.midas = midas;
        playerExperience.doubleXp = doubleXp;
        playerGold.doubleGold = doubleGold;
        playerShooting.shortRange = shortRange;
        playerMovement.dashCreatesSpecialOnStart = dashCreatesSpecialOnStart;
        playerMovement.dashCreatesSpecialOnEnd = dashCreatesSpecialOnEnd;
        playerShooting.doubleShot = doubleShot;
        playerShooting.tripleShot = tripleShot;

    }

    public void UpdateUGUI()
    {
        attackDmgText.text = minDamage.ToString("0.0") + " - " + maxDamage.ToString("0.0");

        specialAttackText.text = specialAttackDamage.ToString("0.00");

        attackSpeedText.text = attackSpeed.ToString("0.00");

        criticalChanceText.text = criticalChance.ToString("0.0") +"%";

        criticalDamageText.text = criticalDamage.ToString("0.00")+"%";

        moveSpeedText.text = moveSpeed.ToString("0.00");

        maxHealthText.text = maxHealth.ToString();
    }


    public void MaxDmgIncrease(int dmgIncrease)
    {
        minDamage += minDamage * dmgIncrease/100;
        maxDamage += maxDamage * dmgIncrease/100;
    }

    public void MaxHealthIncrease(int health)
    {
        maxHealth += health;
        playerHealth.health = maxHealth;
    }

    public void MoveSpeedIncrease(int moveSpeedIncrease)
    {
        moveSpeed += moveSpeed * moveSpeedIncrease / 100;
    }

    public void AttackSpeedIncrease(int attackSpeedIncrease)
    {
        attackSpeed -= attackSpeed * attackSpeedIncrease / 100;
    }

    public void CriticalChanceIncrease(int criticalChanceIncrease)
    {
        criticalChance += criticalChanceIncrease;
    }

    public void CriticalDamageIncrease(int criticalDamageIncrease)
    {
        criticalDamage += criticalDamage * criticalDamageIncrease / 100;
    }

    public void SpecialAttackDmgIncrease(int specialAttackDmgIncrease)
    {
        specialAttackDamage += specialAttackDamage * specialAttackDmgIncrease / 100;
    }

    public void SpecialAttackCooldownDecrease(int specialCooldownDecrease)
    {
        specialAttackCooldown -= specialAttackCooldown * specialCooldownDecrease / 100;
    }

    public void BothAttackDmgIncrease(int bothAttackDmgIncrease)
    {
        minDamage += minDamage * bothAttackDmgIncrease / 100;
        maxDamage += maxDamage * bothAttackDmgIncrease / 100;
        specialAttackDamage += specialAttackDamage * bothAttackDmgIncrease / 100;
    }

    public void DashCooldownDecrease(int dashCooldownDecrease)
    {
        dashCooldown -= dashCooldown * dashCooldownDecrease / 100;
    }

    public void DashRangeIncrease(int dashRangeIncrease)
    {
        dashRange += dashRange * dashRangeIncrease / 100;
    }

    public void HitInvulnerabilityIncrease(int hitInvulnerabilityIncrease)
    {
        hitInvulnerability += hitInvulnerability * hitInvulnerabilityIncrease / 100;
    }

    public void DiceRerolls(int diceRerolls)
    {
        rerolls += diceRerolls;
    }

    public void AttackSpeedDecrease(int attackSpeedDecrease)
    {
        attackSpeed += attackSpeed * attackSpeedDecrease / 100;
    }

}
