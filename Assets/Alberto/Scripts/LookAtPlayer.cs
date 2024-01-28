using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        this.GetComponent<SpriteRenderer>().flipX = transform.position.x > player.position.x ? true : false;
    }
}
