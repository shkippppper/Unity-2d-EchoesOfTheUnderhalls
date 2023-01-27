using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requiredXp;

    private float lerpTimer;
    private float delayTimer;
    public bool doubleXp;

    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;

    
    [Header("Calculations")]
    [Range(1f, 300f)]
    public float additionMultiplier = 300;
    [Range(2f, 4f)]
    public float powerMultiplier = 2;
    [Range(7f, 14f)]
    public float divisionMultiplier = 14;



    [Header("Texts")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expPercentageText;

    public UpgradeUI upgradesManager;


    // Start is called before the first frame update
    void Start()
    {
        requiredXp = CalculateRequiredXp();
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        expPercentageText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUi();
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            GainExperienceFlatRate(100);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GainExperienceFlatRate(500);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GainExperienceFlatRate(1000);
        }
        if (currentXp > requiredXp)
        {
            LevelUp();
        }
    }

    public void UpdateXpUi()
    {
        float xpFraction = currentXp / requiredXp;
        float FXP = frontXpBar.fillAmount;
        if (FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if (delayTimer > 1)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }

        expPercentageText.text = ((int)Mathf.Floor(currentXp / requiredXp*100)).ToString();
        levelText.text = level.ToString();
    }

    public void GainExperienceFlatRate(int xpGained)
    {
        if (doubleXp)
        {
            xpGained *= 2;
        }
        currentXp += xpGained;
        lerpTimer = 0f;
    }
    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        requiredXp = CalculateRequiredXp();

        upgradesManager.OpenPanel();
    }

    private int CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
