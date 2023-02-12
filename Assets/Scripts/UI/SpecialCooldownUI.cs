using UnityEngine;
using UnityEngine.UI;

public class SpecialCooldownUI : MonoBehaviour
{
    private Image specialAttackVisualImage;
    public PlayerShooting playerShooting;

    private void Awake()
    {
        specialAttackVisualImage = GetComponent<Image>();    
    }

    private void Update()
    {
        specialAttackVisualImage.fillAmount = (Time.time - playerShooting.timeSinceLastSpecial)/ playerShooting.fireRateSpecial;

    }

}
