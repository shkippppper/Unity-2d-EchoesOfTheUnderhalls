using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossTextManager : MonoBehaviour
{
    public TextMeshPro chatText;
    public GameObject chatContainer;
    public List<string> chatTexts;
    public List<bool> chatRead;
    public EnemyHealth bossHp;

    private void Start()
    {
        OpenChat(0);
    }
    

    private void Update()
    {

        if (bossHp.currentHealth / bossHp.startingHealth < 0.85 && !chatRead[1])
        {
            OpenChat(1);
        }
        else if (bossHp.currentHealth / bossHp.startingHealth < 0.65 && !chatRead[2])
        {
            OpenChat(2);

        }
        else if (bossHp.currentHealth / bossHp.startingHealth < 0.35 && !chatRead[3])
        {
            OpenChat(3);

        }
        else if (bossHp.currentHealth / bossHp.startingHealth < 0.07 && !chatRead[4])
        {
            OpenChat(4);

        }
    }

    public void OpenChat(int chatIndex)
    {
        chatRead[chatIndex] = true;
        chatText.text = chatTexts[chatIndex];
        chatContainer.SetActive(true);

        Invoke(nameof(CloseChat), 12f);
    }

    public void CloseChat()
    {
        chatContainer.SetActive(false);
    }
}


