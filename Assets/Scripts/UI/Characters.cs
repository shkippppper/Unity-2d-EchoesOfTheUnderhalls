using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<RuntimeAnimatorController> animatorControllers;
    public List<bool> unlockedCharacters;
    public int characterIndex;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    private void Awake()
    {
        playerSpriteRenderer = transform.parent.GetChild(0).GetComponent<SpriteRenderer>();
        playerAnimator = transform.parent.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        LoadData();
        unlockedCharacters[0] = true;
        characterIndex = 0;
        playerSpriteRenderer.sprite = sprites[0];
        playerAnimator.runtimeAnimatorController = animatorControllers[0];

    }

    private void Update()
    {
        ChangeCharacter(characterIndex);
        SaveData();
    }


    public void ChangeCharacter(int character)
    {
        characterIndex = character;
        playerSpriteRenderer.sprite = sprites[character];
        playerAnimator.runtimeAnimatorController = animatorControllers[character];
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Pyromancer", boolToInt(unlockedCharacters[0]));
        PlayerPrefs.SetInt("Savage", boolToInt(unlockedCharacters[1]));
        PlayerPrefs.SetInt("Ranger", boolToInt(unlockedCharacters[2]));
        PlayerPrefs.SetInt("Occultist", boolToInt(unlockedCharacters[3]));
        PlayerPrefs.SetInt("Tinkerer", boolToInt(unlockedCharacters[4]));
        PlayerPrefs.SetInt("Druid", boolToInt(unlockedCharacters[5]));
    }

    public void LoadData()
    {
        unlockedCharacters[0] = intToBool(PlayerPrefs.GetInt("Pyromancer"));
        unlockedCharacters[1] = intToBool(PlayerPrefs.GetInt("Savage"));
        unlockedCharacters[2] = intToBool(PlayerPrefs.GetInt("Ranger"));
        unlockedCharacters[3] = intToBool(PlayerPrefs.GetInt("Occultist"));
        unlockedCharacters[4] = intToBool(PlayerPrefs.GetInt("Tinkerer"));
        unlockedCharacters[5] = intToBool(PlayerPrefs.GetInt("Druid"));


    }

    private int boolToInt(bool val)
    {
        if (val)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    private bool intToBool(int val)
    {
        if (val !=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
