using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraUP : MonoBehaviour
{
     public float moveDuration = 5.0f; // Duración del desplazamiento hacia arriba
    public GameObject objectToActivate; // GameObject a activar después del desplazamiento
    public GameObject objectToActivate2;
    public GameObject objectToActivate3;

    private bool hasMoved = false;

    // Llama a esta función desde otro script o evento para iniciar el desplazamiento
    public void MoveCameraUpGradually()
    {
        if (!hasMoved)
        {
            StartCoroutine(MoveUpGradually());
        }
    }

    IEnumerator MoveUpGradually()
    {
        //yield return new WaitForSeconds(14.0f);
        hasMoved = true;

        float elapsedTime = 0;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + Vector3.up;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la posición final sea exacta
        transform.position = targetPosition;
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);
            objectToActivate3.SetActive(true);
        }

        // Esperar 20 segundos antes de activar el objeto y volver al menú principal
        yield return new WaitForSeconds(17.0f);

        // Activar el objeto
        

        // Cambiar a la escena del menú principal
        SceneManager.LoadScene("Main_Menu");
    }
}
