using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] private GameObject _talkings;
    public void Talk () 
    {
        this.GetComponent<Collider2D>().enabled = false;
        _talkings.SetActive(true);
    }
}
