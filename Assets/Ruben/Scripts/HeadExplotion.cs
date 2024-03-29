using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadExplotion : MonoBehaviour
{
    [SerializeField] private GameObject particleSystem;
    [SerializeField] private GameObject HaHa;
    [SerializeField] private float _timeToBoom = 1f;
    private Animator animator;

    public void StartAnim()
    {
        //particleSystem = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();

        // Llamar a la función después de 4 segundos
        Invoke("ActivateParticlesAndAnimator", _timeToBoom);
        HaHa.SetActive(true);
    }

    void ActivateParticlesAndAnimator()
    {
        

        // Activar el componente Animator
        if (animator != null)
        {
            animator.enabled = true;
        }
        

        // Llamar a la función para eliminar el objeto después de 4 segundos más
        Invoke("Boom", 1.8f);
        Invoke("DestroyGameObject", 5.4f);
    }

    void Boom()
    {
        HaHa.SetActive(false);
        // Activar el objeto de partículas
        if (particleSystem != null)
        {
            particleSystem.SetActive(true);
        }
    }

    void DestroyGameObject()
    {
        // Detener las partículas si están activas
        //if (particleSystem != null && particleSystem.isPlaying)
        //{
        //    particleSystem.Stop();
        //}

        // Destruir el objeto actual
        Destroy(gameObject);
    }
}
