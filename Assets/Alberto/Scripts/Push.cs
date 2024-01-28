using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private float fuerza = 10f;
    [SerializeField] private float angulo = 45f;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AplicarFuerzaEnAngulo();
        }
    }
    private void AplicarFuerzaEnAngulo()
    {
        float fuerzaX = fuerza * Mathf.Cos(angulo * Mathf.Deg2Rad);
        float fuerzaY = fuerza * Mathf.Sin(angulo * Mathf.Deg2Rad);

        GetComponent<Rigidbody2D>().AddForce(new Vector3(fuerzaX, fuerzaY, 0f), ForceMode2D.Impulse);
    }
    
}
