using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankImageUpdater : MonoBehaviour
{
    public Sprite[] ranks;
    public Image currentImage;
    public Image nextLVLImage;
    private int imageIndex;
    private GameObject player;
    private PlayerExperience playerExperience;

    private void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
            playerExperience = player.GetComponent<PlayerExperience>();
        }

    }

    private void Start()
    {
        currentImage.sprite = ranks[0];
        nextLVLImage.sprite = ranks[1];
        imageIndex = 0;
    }


    private void Update()
    {
        imageIndex = Mathf.FloorToInt (playerExperience.level / 5);
        if (imageIndex > 15)
        {
            imageIndex = 15;
        }
        
        var imageIndexPlusOne = imageIndex + 1;
        currentImage.sprite = ranks[imageIndex];
        if (imageIndexPlusOne > 15)
        {
            nextLVLImage.sprite = ranks[15];

        }
        else
        {
            nextLVLImage.sprite = ranks[imageIndexPlusOne];

        }


    }
}
