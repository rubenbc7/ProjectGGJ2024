using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float startTime = 2.0f;

    private float originalVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Asegurarse de que el audioClip está asignado
        if (audioClip != null)
        {
            audioSource.clip = audioClip;

            // Iniciar la reproducción desde el segundo especificado
            audioSource.time = startTime;

            // Almacenar el volumen original para restaurarlo después del fade out
            originalVolume = audioSource.volume;

            // Comenzar el fade in
            StartCoroutine(FadeIn());
        }
        else
        {
            Debug.LogError("No se ha asignado un AudioClip al AudioSource.");
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeInDuration)
        {
            audioSource.volume = Mathf.Lerp(0, originalVolume, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = originalVolume;
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeOutDuration)
        {
            audioSource.volume = Mathf.Lerp(originalVolume, 0, elapsedTime / fadeOutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }

    // Llamado cuando desees detener el audio con fade out
    public void StopWithFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}
