using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimations : MonoBehaviour
{
    private Vector3 posicionAnterior;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private string characterAnimationIdleName;
    [SerializeField] private string characterAnimationWalkingName;
    [SerializeField] private string characterAnimationPush;

    private void Start()
    {
        // Guardar la posición inicial del objeto
        posicionAnterior = transform.position;
    }

    private void Update()
    {
        Movemement();
    }

    void Movemement() 
    {
        // Verificar si la posición actual es diferente a la posición anterior
        if (transform.position != posicionAnterior)
        {
            // El objeto se está moviendo
            characterAnimator.Play(characterAnimationWalkingName);
        }
        else
        {
            // El objeto no se está moviendo
            characterAnimator.Play(characterAnimationIdleName);
        }

        // Actualizar la posición anterior al final del frame
        posicionAnterior = transform.position;
    }

    public void Push()
    {
        characterAnimator.Play(characterAnimationPush);
        Debug.Log("aad");
    }
}
