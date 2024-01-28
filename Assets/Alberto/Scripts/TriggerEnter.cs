using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEnter;
    [SerializeField] private string _tag;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(_tag))
        {
            _triggerEnter.Invoke();
        }
    }

    public void deactivateCollider2D()
    {
        this.GetComponent<Collider2D>().enabled = false;
    }
}
