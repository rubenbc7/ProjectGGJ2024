using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] private GameObject _talkings;
    public void Talk () 
    {
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Dialogue>().enabled = true;
        _talkings.SetActive(true);
    }
}
