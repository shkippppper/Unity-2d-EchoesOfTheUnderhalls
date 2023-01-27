using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RerollScript : MonoBehaviour
{
    public int rerolls;
    public TextMeshProUGUI rerollsText;
    public Button rerollButton;
    public UpgradeChooser upgradeChooser;
    public Stats stats;
    public PlayerExperience playerExperience;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Rerolls"))
        {
            rerolls = PlayerPrefs.GetInt("Rerolls");
        }

    }

    private void Update()
    {
        if (rerolls <= 0)
        {
            rerollButton.interactable = false;
        }
        //else if (playerExperience.level == 1 || playerExperience.level % 20 == 0)
        //{
        //    rerollButton.interactable = false;
        //}
        else
        {
            rerollButton.interactable = true;
        }

        rerollsText.text = rerolls.ToString();
    }

    public void IncreaseRerollsPerma(int rerollIncrease)
    {
        PlayerPrefs.SetInt("Rerolls", PlayerPrefs.GetInt("Rerolls") + rerollIncrease);
    }

    public void Reroll()
    {
        upgradeChooser.UpgradesCalled();
        stats.rerolls -= 1;
    }



}
