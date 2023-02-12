using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject characterChooser;
    public GameObject powerUps;
    public GameObject enemySpawner;
    


    private void Update()
    {
        if (characterChooser.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                CloseCharacterChooser();
            }
        }
    }

    public void CloseCharacterChooser()
    {
        characterChooser.SetActive(false);
        powerUps.SetActive(true);
        enemySpawner.SetActive(true);
    }

}
