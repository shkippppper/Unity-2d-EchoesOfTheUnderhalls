using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChooser : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;
    

    void Start()
    {
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    private void OnDisable()
    {
        playerMovement.enabled = true;
        playerShooting.enabled = true;
    }
}
