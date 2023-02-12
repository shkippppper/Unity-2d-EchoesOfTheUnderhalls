using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeNotification : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI upgradeText;
    public UpgradeUI upgradeUI;
    public UpgradeChooser upgradeChooser;


    public void TriggerHighlight(int upgrade)
    {

        if(upgrade > 38)
        {
            upgradeText.text = upgradeChooser.crimsonTexts[upgrade - upgradeChooser.textsList.Count];
        }
        else
        {
            upgradeText.text = upgradeChooser.textsList[upgrade];
        }

        animator.SetTrigger("TrUpgradeNotification");
      
    }
}
