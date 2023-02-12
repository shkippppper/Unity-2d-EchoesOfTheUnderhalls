using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BossHp : MonoBehaviour
{
    public TextMeshProUGUI bossName;
    public PlayerExperience playerExperience;
    public PlayerHealth playerHealth;
    public Animator backgroundAnimator;
    public GameObject bossContainer;
    public GameObject hpContainer;
    public Image hpImage;
    private int bossMaxHp;
    public Vector3 bossLocation;
    public Vector3 mapLocation;
    public GameObject enemySpawner;

    public List<string> names;
    public List<bool> hasStarted;
    public List<bool> hasRun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerExperience.level == 19)
        {
            if (!hasStarted[0])
            {
                InitiateBossFight();
                hasStarted[0] = true;
                Invoke(nameof(HealthBarAppear), 0.15f);
                bossName.text = names[0];
                bossContainer.transform.GetChild(0).gameObject.SetActive(true);

            }
            
            if (!hasRun[0])
            {
                bossMaxHp = bossContainer.transform.GetChild(0).GetComponent<EnemyHealth>().startingHealth;
                hasRun[0] = true;
            }


            if(bossContainer.transform.GetChild(0).GetComponent<EnemyHealth>().currentHealth > 0)
            {
                hpImage.fillAmount = bossContainer.transform.GetChild(0).GetComponent<EnemyHealth>().currentHealth / bossMaxHp;
            }
            else if (bossContainer.transform.GetChild(0).GetComponent<EnemyHealth>().currentHealth < 0)
            {
                HealthBarDissapear();
            }


        }

        else if (playerExperience.level == 39)
        {
            if (!hasStarted[1])
            {
                InitiateBossFight();
                hasStarted[1] = true;
                Invoke(nameof(HealthBarAppear), 0.15f);
                bossName.text = names[1];
                bossContainer.transform.GetChild(1).gameObject.SetActive(true);

            }

            if (!hasRun[1])
            {
                bossMaxHp = bossContainer.transform.GetChild(1).GetComponent<EnemyHealth>().startingHealth;
                hasRun[1] = true;
            }


            if (bossContainer.transform.GetChild(1).GetComponent<EnemyHealth>().currentHealth > 0)
            {
                hpImage.fillAmount = bossContainer.transform.GetChild(1).GetComponent<EnemyHealth>().currentHealth / bossMaxHp;
            }
            else if (bossContainer.transform.GetChild(1).GetComponent<EnemyHealth>().currentHealth < 0)
            {
                HealthBarDissapear();
            }



        }
        else if(playerExperience.level == 59)
        {
            if (!hasStarted[2])
            {
                InitiateBossFight();
                hasStarted[2] = true;
                Invoke(nameof(HealthBarAppear), 0.15f);
                bossName.text = names[2];
                bossContainer.transform.GetChild(2).gameObject.SetActive(true);

            }

            if (!hasRun[2])
            {
                bossMaxHp = bossContainer.transform.GetChild(2).GetComponent<EnemyHealth>().startingHealth;
                hasRun[2] = true;
            }


            if (bossContainer.transform.GetChild(2).GetComponent<EnemyHealth>().currentHealth > 0)
            {
                hpImage.fillAmount = bossContainer.transform.GetChild(2).GetComponent<EnemyHealth>().currentHealth / bossMaxHp;
            }
            else if (bossContainer.transform.GetChild(2).GetComponent<EnemyHealth>().currentHealth < 0)
            {
                HealthBarDissapear();
            }

        }
        else if(playerExperience.level == 79)
        {
            if (!hasStarted[3])
            {
                InitiateBossFight();
                hasStarted[3] = true;
                Invoke(nameof(HealthBarAppear), 0.15f);
                bossName.text = names[3];
                bossContainer.transform.GetChild(3).gameObject.SetActive(true);

            }

            if (!hasRun[3])
            {
                bossMaxHp = bossContainer.transform.GetChild(3).GetComponent<EnemyHealth>().startingHealth;
                hasRun[3] = true;
            }


            if (bossContainer.transform.GetChild(3).GetComponent<EnemyHealth>().currentHealth > 0)
            {
                hpImage.fillAmount = bossContainer.transform.GetChild(3).GetComponent<EnemyHealth>().currentHealth / bossMaxHp;
            }
            else if (bossContainer.transform.GetChild(3).GetComponent<EnemyHealth>().currentHealth < 0)
            {
                HealthBarDissapear();
            }

        }





    }

    public void InitiateBossFight()
    {
        enemySpawner.SetActive(false);

        //make invulnerable
        playerHealth.TakeDamage(757);

        //blackanimation
        backgroundAnimator.SetTrigger("ToBlackWhite");

        //teleport player
        Invoke(nameof(TeleportPlayerToBoss), 0.3f);

    }

    public void EndBossFight()
    {
        enemySpawner.SetActive(true);

        //make invulnerable
        playerHealth.TakeDamage(757);

        //blackanimation
        backgroundAnimator.SetTrigger("ToBlackWhite");

        //health bar dissapearrs
        HealthBarDissapear();

        //teleport player
        Invoke(nameof(TeleportPlayerToMap), 0.3f);
    }

    public void TeleportPlayerToBoss()
    {
        playerExperience.gameObject.transform.localPosition = bossLocation;
    }

    public void TeleportPlayerToMap()
    {

        playerExperience.gameObject.transform.localPosition = mapLocation;
    }


    public void HealthBarAppear()
    {
        hpContainer.SetActive(true);

    }

    public void HealthBarDissapear()
    {
        hpContainer.SetActive(false);
    }
}
