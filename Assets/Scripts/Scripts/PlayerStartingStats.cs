using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingStats : MonoBehaviour
{
    private Stats stats;

    [Header("Stats")]
    public float minDamage = 5;  //1
    public float maxDamage = 7;  //1
    public float specialAttackDamage = 20; //2
    public float specialAttackCooldown = 2;
    public float attackSpeed = 0.5f;  //3
    public float criticalChance = 1f; //4
    public float criticalDamage = 40f; //5
    public float dashCooldown = 1f;
    public float hitInvulnerability = 0.5f;
    public float dashRange = 5f;
    public float maxHealth = 3; //6
    public float moveSpeed = 1f; //7

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



    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    public void UpdateStats()
    {
        stats.minDamage = minDamage;
        stats.maxDamage = maxDamage;
        stats.specialAttackDamage = specialAttackDamage;
        stats.specialAttackCooldown = specialAttackCooldown;
        stats.attackSpeed = attackSpeed;
        stats.criticalChance = criticalChance;
        stats.criticalDamage = criticalDamage;
        stats.dashCooldown = dashCooldown;
        stats.hitInvulnerability = hitInvulnerability;
        stats.dashRange = dashRange;
        stats.maxHealth = maxHealth;
        stats.moveSpeed = moveSpeed;

        stats.attackPierces = attackPierces;
        stats.shootTheOpposite = shootTheOpposite;
        stats.attacksHaveChanceForSpecial = attacksHaveChanceForSpecial;
        stats.midas = midas;
        stats.doubleXp = doubleXp;
        stats.doubleGold = doubleGold;
        stats.dashCreatesSpecialOnStart = dashCreatesSpecialOnStart;
        stats.dashCreatesSpecialOnEnd = dashCreatesSpecialOnEnd;
        stats.tripleShot = tripleShot;
        stats.doubleShot = doubleShot;
        stats.specialsHaveChanceForAttack = specialsHaveChanceForAttack;
    }
}
