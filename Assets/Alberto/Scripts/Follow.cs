using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform  target;
    [SerializeField] private float minDistanceToTarget;

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        
        if (distanceToTarget > minDistanceToTarget)
        {
            float posX = Mathf.Lerp(transform.position.x, target.position.x, velocity * Time.deltaTime);
            transform.position = new Vector2(posX, transform.position.y);
        }
    }
    
}
