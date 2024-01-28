using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [Header("Objeto de dialogos")]
    [SerializeField] private GameObject _talkings;

    [Header("Propiedades de empuje")]
    [SerializeField] private float force = 10f;
    [SerializeField] private float angle = 45f;
    [SerializeField] private Rigidbody2D targetRb;

    [SerializeField] private Animator characterAnimator;
    [SerializeField] private string characterAnimationPush;
    public void Talk () 
    {
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Dialogue>().enabled = true;
        _talkings.SetActive(true);
    }

    public void Follow ()
    {
        this.GetComponent<Follow>().enabled = true;
    }

    public void Unfollow ()
    {
        this.GetComponent<Follow>().enabled = false;
    }

    public void Push()
    {
        float fx = force * Mathf.Cos(angle * Mathf.Deg2Rad);
        float fy = force * Mathf.Sin(angle * Mathf.Deg2Rad);

        targetRb.AddForce(new Vector3(fx, fy, 0f), ForceMode2D.Impulse);
        characterAnimator.Play(characterAnimationPush);
    }

    public void ReactivateTrigger () 
    {
        this.GetComponent<Collider2D>().enabled = true;
    }
}
