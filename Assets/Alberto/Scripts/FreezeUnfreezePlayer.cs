using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeUnfreezePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public void FreezePlayer () 
    {
        PlayerController playerController = _player.GetComponent<PlayerController>();
        Rigidbody2D playerRb = _player.GetComponent<Rigidbody2D>();

        if (playerController != null)
        {
            playerController.enabled = false;
            playerRb.simulated = false;
        }
    }

    public void UnfreezePlayer () 
    {
        PlayerController playerController = _player.GetComponent<PlayerController>();
        Rigidbody2D playerRb = _player.GetComponent<Rigidbody2D>();

        if (playerController != null)
        {
            playerController.enabled = true;
            playerRb.simulated = true;
        }
    }
}
