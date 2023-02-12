using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingStats : MonoBehaviour
{
    private Stats stats;
    public Characters characters;
    public PlayerHealth playerHealth;

    [Header("Stats")]
    private float minDamage;  //1
    private float maxDamage;  //1
    private float specialAttackDamage; //2
    private float specialAttackCooldown;
    private float attackSpeed;  //3
    private float criticalChance; //4
    private float criticalDamage; //5
    private float dashCooldown;
    private float hitInvulnerability;
    private float dashRange;
    private float maxHealth; //6
    private float moveSpeed; //7

    private bool attackPierces = false;
    private bool shootTheOpposite = false;
    private bool attacksHaveChanceForSpecial = false;
    private bool specialsHaveChanceForAttack = false;
    private bool midas = false;
    private bool doubleXp = false;
    private bool doubleGold = false;
    private bool dashCreatesSpecialOnStart = false;
    private bool dashCreatesSpecialOnEnd = false;
    private bool tripleShot = false;
    private bool doubleShot = false;

    public int characterIndex = 0;

    public List<CharacterStats> scriptableObjectsCharacterStats;

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    private void Start()
    {
        UpdateStatsFromScriptableObjects(characterIndex);
        UpdateStats();
    }


    private void Update()
    {

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


    public void UpdateStatsFromScriptableObjects(int characterIndex)
    {
        minDamage = scriptableObjectsCharacterStats[characterIndex].minDamage;
        maxDamage = scriptableObjectsCharacterStats[characterIndex].maxDamage;
        specialAttackDamage = scriptableObjectsCharacterStats[characterIndex].specialAttackDamage;
        specialAttackCooldown = scriptableObjectsCharacterStats[characterIndex].specialAttackCooldown;
        attackSpeed = scriptableObjectsCharacterStats[characterIndex].attackSpeed;
        criticalChance = scriptableObjectsCharacterStats[characterIndex].criticalChance;
        criticalDamage = scriptableObjectsCharacterStats[characterIndex].criticalDamage;
        dashCooldown = scriptableObjectsCharacterStats[characterIndex].dashCooldown;
        hitInvulnerability = scriptableObjectsCharacterStats[characterIndex].hitInvulnerability;
        dashRange = scriptableObjectsCharacterStats[characterIndex].dashRange;
        maxHealth = scriptableObjectsCharacterStats[characterIndex].maxHealth;
        moveSpeed = scriptableObjectsCharacterStats[characterIndex].moveSpeed;

        attackPierces = scriptableObjectsCharacterStats[characterIndex].attackPierces;
        shootTheOpposite = scriptableObjectsCharacterStats[characterIndex].shootTheOpposite;
        attacksHaveChanceForSpecial = scriptableObjectsCharacterStats[characterIndex].attacksHaveChanceForSpecial;
        midas = scriptableObjectsCharacterStats[characterIndex].midas;
        doubleXp = scriptableObjectsCharacterStats[characterIndex].doubleXp;
        doubleGold = scriptableObjectsCharacterStats[characterIndex].doubleGold;
        dashCreatesSpecialOnStart = scriptableObjectsCharacterStats[characterIndex].dashCreatesSpecialOnStart;
        dashCreatesSpecialOnEnd = scriptableObjectsCharacterStats[characterIndex].dashCreatesSpecialOnEnd;
        tripleShot = scriptableObjectsCharacterStats[characterIndex].tripleShot;
        doubleShot = scriptableObjectsCharacterStats[characterIndex].doubleShot;
        specialsHaveChanceForAttack = scriptableObjectsCharacterStats[characterIndex].specialsHaveChanceForAttack;
    }


    public void CharacterChanged(int characterIndex)
    {
        if (characters.unlockedCharacters[characterIndex])
        {
            UpdateStatsFromScriptableObjects(characterIndex);
            UpdateStats();
            playerHealth.health = maxHealth;
        }

    }
}
