using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUIHandler : MonoBehaviour
{
    public TextMeshProUGUI charName;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI mvSpeedText;
    public TextMeshProUGUI critChanceText;
    public TextMeshProUGUI critDmgText;
    public TextMeshProUGUI specialDmgText;
    public TextMeshProUGUI specialCDText;
    public TextMeshProUGUI hitInvulnerabilityText;
    public TextMeshProUGUI dashRangeText;
    public TextMeshProUGUI dashCDText;
    public TextMeshProUGUI maxHpText;
    public TextMeshProUGUI attackDescriptionText;
    public TextMeshProUGUI specialAttackDescriptionText;



    public List<CharacterStats> scriptableObjectsCharacterStats;

    public Characters characters;

    public void ChangeStats(int characterIndex)
    {
        if (characters.unlockedCharacters[characterIndex])
        {
            charName.text = scriptableObjectsCharacterStats[characterIndex].charName;
            attackText.text = scriptableObjectsCharacterStats[characterIndex].minDamage + "-" + scriptableObjectsCharacterStats[characterIndex].maxDamage;
            attackSpeedText.text = scriptableObjectsCharacterStats[characterIndex].attackSpeed.ToString();
            mvSpeedText.text = scriptableObjectsCharacterStats[characterIndex].moveSpeed.ToString();
            critChanceText.text = scriptableObjectsCharacterStats[characterIndex].criticalChance.ToString();
            critDmgText.text = scriptableObjectsCharacterStats[characterIndex].criticalDamage.ToString();
            specialDmgText.text = scriptableObjectsCharacterStats[characterIndex].specialAttackDamage.ToString();
            specialCDText.text = scriptableObjectsCharacterStats[characterIndex].specialAttackCooldown.ToString();
            hitInvulnerabilityText.text = scriptableObjectsCharacterStats[characterIndex].hitInvulnerability.ToString();
            dashRangeText.text = scriptableObjectsCharacterStats[characterIndex].dashRange.ToString();
            dashCDText.text = scriptableObjectsCharacterStats[characterIndex].dashCooldown.ToString();
            maxHpText.text = scriptableObjectsCharacterStats[characterIndex].maxHealth.ToString();
            attackDescriptionText.text = scriptableObjectsCharacterStats[characterIndex].physicalAttackText.ToString();
            specialAttackDescriptionText.text = scriptableObjectsCharacterStats[characterIndex].specialAttackText.ToString();

        }
        else
        {
            charName.text = "????? ??????";
            attackText.text = "?-?";
            attackSpeedText.text = "?";
            mvSpeedText.text = "?";
            critChanceText.text = "?";
            critDmgText.text = "?";
            specialDmgText.text = "?";
            specialCDText.text = "?";
            hitInvulnerabilityText.text = "?";
            dashRangeText.text = "?";
            dashCDText.text = "?";
            maxHpText.text = "?";
            attackDescriptionText.text = "??????? ????? ??? ? ????? ???? ????????? ???";
            specialAttackDescriptionText.text = "??????? ??????? ????????? ????? ??? ? ??????? ??????? ??????";
        }
    }
}