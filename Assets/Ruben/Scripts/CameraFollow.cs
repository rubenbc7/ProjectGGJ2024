using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform target;                   
    public float verticalOffset = 2f;          
    public float lookAheadDistanceX = 6f;     
    public float lookSmoothTimeX = 0.5f;       
    public float verticalSmoothTime = 0.2f;   

    private Vector3 currentVelocity;
    private Vector3 lookAheadPos;

    private void Update()
    {
        if (target != null)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        // Obtiene la posición objetivo de la cámara
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + verticalOffset, transform.position.z);

        // Calcula la posición de mirada anticipada
        lookAheadPos = Vector3.Lerp(lookAheadPos, target.position + Vector3.right * lookAheadDistanceX, Time.deltaTime * lookSmoothTimeX);

        // Combina la posición objetivo y la posición de mirada anticipada
        targetPosition += new Vector3(lookAheadPos.x - transform.position.x, 0, 0);

        // Suavizado de la posición vertical de la cámara
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, verticalSmoothTime);
    }
}
