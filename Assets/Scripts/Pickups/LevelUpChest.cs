using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpChest : MonoBehaviour
{
    private GameObject upgradesManager;
    private UpgradeUI upgradeUI;

    private void Awake()
    {
        if (GameObject.FindWithTag("UpgradesManager") != null)
        {
            upgradesManager = GameObject.FindWithTag("UpgradesManager");
            upgradeUI = upgradesManager.GetComponent<UpgradeUI>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            upgradeUI.OpenPanel();
            Destroy(gameObject);
        }
    }

}
