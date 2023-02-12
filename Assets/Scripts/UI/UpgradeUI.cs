using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject levelUpPanel;
    public PlayerExperience playerExperience;
    public Button randomDice;
    public Button rerollDice;
    private UpgradeChooser upgradeChooser;
    private Stats stats;
    public List<int> upgradesList;
    public UpgradeNotification upgradeNotification;
    public List<int> upgradesTakenCrimson;
    

    private void Awake()
    {
        upgradeChooser = GetComponent<UpgradeChooser>();
        stats = GetComponent<Stats>();
    }

    private void Start()
    {
        randomDice.interactable = false;
        rerollDice.interactable = false;
    }


    public void OpenPanel()
    {
        upgradeChooser.UpgradesCalled();
        levelUpPanel.SetActive(true);
        if (playerExperience.level == 1 || playerExperience.level % 20 == 0)
        {
            randomDice.interactable = false;
            rerollDice.interactable = false;
        }
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        randomDice.interactable = true;
        rerollDice.interactable = true;
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RandomUpgrade()
    {
        int randomUpgrade = Random.Range(0, upgradeChooser.spriteList.Count);
        print(randomUpgrade);
        Upgrade(randomUpgrade);

    }

    public void FirstBtnClicked()
    {
        if (playerExperience.level == 1 || playerExperience.level % 20 == 0)
        {
            Upgrade(upgradeChooser.spriteList.Count + upgradeChooser.randomFirst);
        }
        else
        {
            Upgrade(upgradeChooser.randomFirst);
        }
    }

    public void SecondBtnClicked()
    {
        if (playerExperience.level == 1 || playerExperience.level % 20 == 0)
        {
            Upgrade(upgradeChooser.spriteList.Count + upgradeChooser.randomSecond);
        }
        else
        {
            Upgrade(upgradeChooser.randomSecond);
        }
    }

    public void ThirdBtnClicked()
    {
        if (playerExperience.level == 1 || playerExperience.level % 20 == 0)
        {
            Upgrade(upgradeChooser.spriteList.Count + upgradeChooser.randomThird);
        }
        else
        {
            Upgrade(upgradeChooser.randomThird);
        }
    }


    public void Upgrade(int upgrade)
    {

        upgradeNotification.TriggerHighlight(upgrade);

        switch (upgrade)
        {
            case 0:
                //Main Attack Dmg Increase 10 %
                stats.MaxDmgIncrease(10);
                break;
            case 1:
                //Main Attack Dmg Increase 15 %
                stats.MaxDmgIncrease(15);
                break;
            case 2:
                //Main Attack Dmg Increase 20 %
                stats.MaxDmgIncrease(20);
                break;


            case 3:
                //Max Health Increased By 1 And Heal
                stats.MaxHealthIncrease(1);
                break;
            case 4:
                //Max Health Increased By 2 And Heal
                stats.MaxHealthIncrease(2);
                break;
            case 5:
                //Max Health Increased By 3 And Heal
                stats.MaxHealthIncrease(3);
                break;


            case 6:
                //MoveSpeed Increase 1%
                stats.MoveSpeedIncrease(1);
                break;
            case 7:
                //MoveSpeed Increase 2%
                stats.MoveSpeedIncrease(2);
                break;
            case 8:
                //MoveSpeed Increase 3%
                stats.MoveSpeedIncrease(3);
                break;


            case 9:
                //Attack Speed Increase 8%
                stats.AttackSpeedIncrease(8);
                break;
            case 10:
                //Attack Speed Increase 10%
                stats.AttackSpeedIncrease(10);
                break;
            case 11:
                //Attack Speed Increase 12%
                stats.AttackSpeedIncrease(12);
                break;


            case 12:
                //Critical Chance Increased By 2
                stats.CriticalChanceIncrease(2);
                break;
            case 13:
                //Critical Chance Increased By 3
                stats.CriticalChanceIncrease(3);
                break;
            case 14:
                //Critical Chance Increased By 5
                stats.CriticalChanceIncrease(5);
                break;


            case 15:
                //Critical Damage Increase 6%
                stats.CriticalDamageIncrease(6);
                break;
            case 16:
                //Critical Damage Increase 12%
                stats.CriticalDamageIncrease(12);
                break;
            case 17:
                //Critical Damage Increase 18%
                stats.CriticalDamageIncrease(18);
                break;


            case 18:
                //Special Attack Damage Increase 10%
                stats.SpecialAttackDmgIncrease(10);
                break;
            case 19:
                //Special Attack Damage Increase 15%
                stats.SpecialAttackDmgIncrease(15);
                break;
            case 20:
                //Special Attack Damage Increase 20 %
                stats.SpecialAttackDmgIncrease(20);
                break;


            case 21:
                //Special Attack Cooldown Decrease 1%
                stats.SpecialAttackCooldownDecrease(1);
                break;
            case 22:
                //Special Attack Cooldown Decrease 2%
                stats.SpecialAttackCooldownDecrease(2);
                break;
            case 23:
                //Special Attack Cooldown Decrease 3%
                stats.SpecialAttackCooldownDecrease(3);
                break;


            case 24:
                //Both Attack Damage Increase 5%
                stats.BothAttackDmgIncrease(5);
                break;
            case 25:
                //Both Attack Damage Increase 7%
                stats.BothAttackDmgIncrease(7);
                break;
            case 26:
                //Both Attack Damage Increase 9%
                stats.BothAttackDmgIncrease(9);
                break;


            case 27:
                //Dash cooldown Decrease 1%
                stats.DashCooldownDecrease(1);
                break;
            case 28:
                //Dash cooldown Decrease 2%
                stats.DashCooldownDecrease(2);
                break;
            case 29:
                //Dash cooldown Decrease 3%
                stats.DashCooldownDecrease(3);
                break;


            case 30:
                //Dash range increase 1%
                stats.DashRangeIncrease(1);
                break;
            case 31:
                //Dash range increase 2%
                stats.DashRangeIncrease(2);
                break;
            case 32:
                //Dash range increase 3%
                stats.DashRangeIncrease(3);
                break;


            case 33:
                //Invulnerability Increase After Being Hit 1%
                stats.HitInvulnerabilityIncrease(1);
                break;
            case 34:
                //Invulnerability Increase After Being Hit 2%
                stats.HitInvulnerabilityIncrease(2);
                break;
            case 35:
                //Invulnerability Increase After Being Hit 3%
                stats.HitInvulnerabilityIncrease(3);
                break;


            case 36:
                //Increase Rerolls By 3
                stats.DiceRerolls(3);
                break;
            case 37:
                //Increase Rerolls By 5
                stats.DiceRerolls(5);
                break;
            case 38:
                //Increase Rerolls By 8
                stats.DiceRerolls(8);
                break;

                //
                //CRIMSON
                //

            case 39:
                //Normal Attacks Have A 10% Chance To Create Special Attacks On Fire
                stats.attacksHaveChanceForSpecial = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 40:
                //Normal Attacks Pierce Through Enemies
                stats.attackPierces = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 41:
                //Fires A Projectile Front And Back
                stats.shootTheOpposite = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 42:
                //Projectiles Always Crit, But Current Damage Decreased To 1
                stats.criticalChance = 100;
                stats.minDamage = 2;
                stats.maxDamage = 3;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 43:
                //All Coins Taken Are Doubled
                stats.doubleGold = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 44:
                //All Experience Taken Is Doubled
                stats.doubleXp = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 45:
                //Current Damage +300%, But Attack Range Decreased Significantly
                stats.MaxDmgIncrease(300);
                stats.shortRange = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 46:
                //Enemies Drop Gold All The Time
                stats.midas = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 47:
                //Increase Rerolls By 20
                stats.DiceRerolls(20);
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 48:
                //Special Attacks Have A 20% Chance To Create Normal Attacks On Fire
                stats.specialsHaveChanceForAttack = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 49:
                //Dash Creates A Special Attack At The End
                stats.dashCreatesSpecialOnEnd = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 50:
                //Dash Creates A Special Attack At The Start
                stats.dashCreatesSpecialOnStart = true;
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 51:
                //Double The Projectiles, But Current Attack Speed Decrease 80%
                stats.doubleShot = true;
                stats.AttackSpeedDecrease(80);
                upgradesTakenCrimson.Add(upgrade);
                break;


            case 52:
                //Triple The Projectiles, But Current Attack Speed Decrease 150%
                stats.tripleShot = true;
                stats.doubleShot = false;
                stats.AttackSpeedDecrease(150);
                upgradesTakenCrimson.Add(upgrade);
                break;



        }
    }


}
