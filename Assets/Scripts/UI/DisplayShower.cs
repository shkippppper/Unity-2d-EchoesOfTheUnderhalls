using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayShower : MonoBehaviour
{
    public Characters charactersScript;
    public List<Sprite> sprites;
    public List<string> names;
    public List<Color> colors;
    public List<Image> characterDisplayImage;

    private TextMeshProUGUI characterName;
    private Image characterImage;
    private Image backgroundImage;
    public Color grayColor;

    private void Awake()
    {
        characterName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        characterImage = transform.GetChild(1).GetComponent<Image>();
        backgroundImage = GetComponent<Image>();
    }


    private void Update()
    {
        int i = 0;
        foreach (var character in charactersScript.unlockedCharacters)
        {
            if (!character)
            {
                LockCharacter(i);
            }
            else
            {
                UnlockCharacter(i);
            }
            i++;
        }
    }


    public void ChangeToScript(int characterIndex)
    {
        if (charactersScript.unlockedCharacters[characterIndex])
        {
            characterImage.sprite = sprites[characterIndex];
            characterImage.color = Color.white;
            backgroundImage.color = colors[characterIndex];
            characterName.text = names[characterIndex];
            charactersScript.ChangeCharacter(characterIndex);
        }
        else
        {
            characterImage.sprite = sprites[characterIndex];
            backgroundImage.color = grayColor;
            characterImage.color = Color.black;
        }



    }

    public void LockCharacter(int characterIndex)
    {
        characterDisplayImage[characterIndex].color = Color.black;
    }


    public void UnlockCharacter(int characterIndex)
    {
        characterDisplayImage[characterIndex].color = Color.white;
        
    }
}
