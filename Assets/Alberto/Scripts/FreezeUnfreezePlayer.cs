using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeUnfreezePlayer : MonoBehaviour
{
    public void FreezePlayer () 
    {
        PlayerController playerController = this.GetComponent<PlayerController>();
        Rigidbody2D playerRb = this.GetComponent<Rigidbody2D>();

        if (playerController != null)
        {
            playerController.enabled = false;
            playerRb.simulated = false;
        }
    }

    public void UnfreezePlayer () 
    {
        PlayerController playerController = this.GetComponent<PlayerController>();
        Rigidbody2D playerRb = this.GetComponent<Rigidbody2D>();

        if (playerController != null)
        {
            playerController.enabled = true;
            playerRb.simulated = true;
        }
    }
}
