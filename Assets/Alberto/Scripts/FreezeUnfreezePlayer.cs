using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeUnfreezePlayer : MonoBehaviour
{
    public void FreezePlayer () 
    {
        Rigidbody2D playerRb = this.GetComponent<Rigidbody2D>();

        if (playerRb != null)
        {
            playerRb.simulated = false;
        }
    }

    public void UnfreezePlayer () 
    {
        Rigidbody2D playerRb = this.GetComponent<Rigidbody2D>();

        if (playerRb != null)
        {
            playerRb.simulated = true;
        }
    }
}
