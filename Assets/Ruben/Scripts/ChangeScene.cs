using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject targetAnimator;
    public string sceneToLoad;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag) && !hasTriggered)
        {
            // Activar el componente Animator
            targetAnimator.SetActive(true);

            // Marcar como activado para evitar repeticiones
            hasTriggered = true;

            // Esperar un tiempo antes de cambiar de escena (ajusta según tus necesidades)
            Invoke("ChangeSceneNow", 2.0f);
        }
    }

    private void ChangeSceneNow()
    {
        // Cambiar de escena
        SceneManager.LoadScene(sceneToLoad);
    }
}
