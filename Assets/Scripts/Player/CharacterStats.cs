using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName ="Character")]
public class CharacterStats : ScriptableObject
{
    public string charName;

    public float minDamage;
    public float maxDamage;  
    public float specialAttackDamage; 
    public float specialAttackCooldown;
    public float attackSpeed;  
    public float criticalChance; 
    public float criticalDamage; 
    public float dashCooldown;
    public float hitInvulnerability;
    public float dashRange;
    public float maxHealth;
    public float moveSpeed;

    public bool attackPierces;
    public bool shootTheOpposite;
    public bool attacksHaveChanceForSpecial;
    public bool specialsHaveChanceForAttack;
    public bool midas;
    public bool doubleXp;
    public bool doubleGold;
    public bool dashCreatesSpecialOnStart;
    public bool dashCreatesSpecialOnEnd;
    public bool tripleShot;
    public bool doubleShot;

    public string physicalAttackText;
    public string specialAttackText;
}
