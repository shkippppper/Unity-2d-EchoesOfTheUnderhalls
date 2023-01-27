using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeChooser : MonoBehaviour
{
    [Header("Content")]
    public List<Sprite> spriteList;
    public List<string> textsList;

    public List<Sprite> crimsonSprites;
    public List<string> crimsonTexts;

    [Header("GameObjects")]
    public TextMeshProUGUI firstBtnText;
    public TextMeshProUGUI secondBtnText;
    public TextMeshProUGUI thirdBtnText;
    public Image firstImage;
    public Image secondImage;
    public Image thirdImage;

    public PlayerExperience playerExperience;
    public UpgradeUI upgradeUI;

    public int randomFirst;
    public int randomSecond;
    public int randomThird;
    


    private void Start()
    {
        UpgradesCalled();

    }

    public void UpgradesCalled()
    {
        if (playerExperience.level == 1 || playerExperience.level % 20 == 0)
        {
            CrimsonUpgradesCalled();
        }
        else
        {
            NormalUpgradesCalled();
        }


    }

    public void CrimsonUpgradesCalled()
    {
        randomFirst = Random.Range(0, crimsonSprites.Count);
        randomSecond = Random.Range(0, crimsonSprites.Count);
        randomThird = Random.Range(0, crimsonSprites.Count);


        foreach (var x in upgradeUI.upgradesTakenCrimson)
        {
            Debug.Log(x.ToString());
        }

        //eliminate the ones that player has chosen
        while (upgradeUI.upgradesTakenCrimson.Contains(randomFirst + spriteList.Count))
        {
            randomFirst = Random.Range(0, crimsonSprites.Count);
            print("reroll1");
        }

        while (upgradeUI.upgradesTakenCrimson.Contains(randomSecond + spriteList.Count) || randomSecond == randomFirst)
        {
            randomSecond = Random.Range(0, crimsonSprites.Count);
            print("reroll2");
        }

        while (upgradeUI.upgradesTakenCrimson.Contains(randomThird + spriteList.Count) || randomThird == randomFirst || randomThird == randomSecond)
        {
            randomThird = Random.Range(0, crimsonSprites.Count);
            print("reroll3");
        }



        firstImage.sprite = crimsonSprites[randomFirst];
        secondImage.sprite = crimsonSprites[randomSecond];
        thirdImage.sprite = crimsonSprites[randomThird];

        firstBtnText.text = crimsonTexts[randomFirst];
        secondBtnText.text = crimsonTexts[randomSecond];
        thirdBtnText.text = crimsonTexts[randomThird];
    }

    public void NormalUpgradesCalled()
    {
        randomFirst = Random.Range(0, spriteList.Count);
        randomSecond = Random.Range(0, spriteList.Count);
        randomThird = Random.Range(0, spriteList.Count);

        //eliminate the duplicates
        while (randomSecond == randomFirst)
        {
            randomSecond = Random.Range(0, spriteList.Count);
        }

        while (randomSecond == randomFirst || randomThird == randomSecond)
        {
            randomThird = Random.Range(0, spriteList.Count);
        }

        firstImage.sprite = spriteList[randomFirst];
        secondImage.sprite = spriteList[randomSecond];
        thirdImage.sprite = spriteList[randomThird];

        firstBtnText.text = textsList[randomFirst];
        secondBtnText.text = textsList[randomSecond];
        thirdBtnText.text = textsList[randomThird];
    }

}
