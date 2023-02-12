using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Unlock : MonoBehaviour
{
    public Characters characters;
    private TextMeshProUGUI text;
    public int selectedCharacterIndex = 0;
    public GameObject buyButton;
    public PlayerGold playerGold;
    public int price;
    public List<Button> buttons;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {


        if(selectedCharacterIndex == 0)
        {
            text.text = "";
            buyButton.SetActive(false);
        }
        else if (selectedCharacterIndex == 1)
        {
            price = 4444;

            if (selectedCharacterIndex != characters.characterIndex)
            {
                text.text = "Unlock: Buy for 4444";
                buyButton.SetActive(true);
            }
            else
            {
                text.text = "";
                buyButton.SetActive(false);
            }
        }

        else if (selectedCharacterIndex == 2)
        {
            price = 7777;
            if (selectedCharacterIndex != characters.characterIndex)
            {
                text.text = "Unlock: Buy for 7777";
                buyButton.SetActive(true);
            }
            else
            {
                text.text = "";
                buyButton.SetActive(false);
            }
        }

        else if (selectedCharacterIndex == 3)
        {
            if (selectedCharacterIndex != characters.characterIndex)
            {
                text.text = "Unlock: Beat The Grandmaster Warlock";
                buyButton.SetActive(false);
            }
            else
            {
                text.text = "";
                buyButton.SetActive(false);
            }
        }


        else if (selectedCharacterIndex == 4)
        {
            price = 2222;
            if (selectedCharacterIndex != characters.characterIndex)
            {
                text.text = "Unlock: Buy for 2222";
                buyButton.SetActive(true);
            }
            else
            {
                text.text = "";
                buyButton.SetActive(false);
            }
        }

        else if (selectedCharacterIndex == 5)
        {
            if (selectedCharacterIndex != characters.characterIndex)
            {
                text.text = "Unlock: Beat the game";
                buyButton.SetActive(false);
            }
            else
            {
                text.text = "";
                buyButton.SetActive(false);
            }
        }

        

    }

    public void ChangeSelectedIndex(int characterIndex)
    {
        selectedCharacterIndex = characterIndex;
    }

    public void Buy()
    {
        if(PlayerPrefs.GetInt("Coins") > price)
        {
            text.text = "";
            buyButton.SetActive(false);
            playerGold.LoseCoin(price);
            characters.unlockedCharacters[selectedCharacterIndex] = true;
            buttons[selectedCharacterIndex].onClick.Invoke();
        }

    }

}
