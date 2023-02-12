using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterColorChangerUI : MonoBehaviour
{
    
    public Color standardColor;
    public Color grayColor;
    public int characterIndex;
    private Image backgroundImage;
    private TextMeshProUGUI characterNameText;
    private string characterName;
    public Characters characters;

    private void Awake()
    {
        backgroundImage = GetComponent<Image>();
        characterNameText = GetComponentInChildren<TextMeshProUGUI>();
        characterName = name;
    }

    void Update()
    {
        if (!characters.unlockedCharacters[characterIndex])
        {
            backgroundImage.color = grayColor;
            characterNameText.text = "????? ??????";
        }
        else
        {
            backgroundImage.color = standardColor;
            characterNameText.text = characterName;

        }
    }
}
