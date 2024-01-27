using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public void isRagdoll()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        foreach (Transform child in transform)
        {
            child.GetComponent<Collider2D>().enabled = true;
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void isNotRagdoll()
    {
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 1;

        foreach (Transform child in transform)
        {
            child.GetComponent<Collider2D>().enabled = false;
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    
}
