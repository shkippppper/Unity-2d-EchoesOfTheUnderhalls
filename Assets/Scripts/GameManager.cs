using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject lost;
    public GameObject won;
    public GameObject rank;
    public GameObject player;

    public Image rankImage;
    public Image playerImage;
    public SpriteRenderer spriteToCopy;
    public Image rankImageToCopy;
    public GameObject sprite;
    public GameObject hp;
    public Characters characters;

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void GameWin()
    {
        FixRankPlayer();

        Time.timeScale = 0;
        won.SetActive(true);
        rank.SetActive(true);
        player.SetActive(true);
        sprite.SetActive(false);
        hp.SetActive(false);
        

    }

    public void GameLose()
    {
        FixRankPlayer();

        Time.timeScale = 0;
        lost.SetActive(true);
        rank.SetActive(true);
        player.SetActive(true);
        sprite.SetActive(false);
        hp.SetActive(false);

    }

    public void FixRankPlayer()
    {
        rankImage.sprite = rankImageToCopy.sprite;
        playerImage.sprite = spriteToCopy.sprite;
    }


    public void UnlockOccultist()
    {
        characters.unlockedCharacters[3] = true;
    }

    public void UnlockDruid()
    {
        characters.unlockedCharacters[5] = true;
    }
}
