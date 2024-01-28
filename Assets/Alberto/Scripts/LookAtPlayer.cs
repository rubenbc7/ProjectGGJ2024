using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = transform.position.x > player.position.x ? -1 * Mathf.Abs(newScale.x) : Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
    }
}
