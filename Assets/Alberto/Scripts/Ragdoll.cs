using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private UnityEvent _onRagdoll;
    private bool ragdollActive = false;
    private List<Transform>  originalChildTransforms = new List<Transform>();
    private List<Vector3> originalPositions = new List<Vector3>();
    private List<Quaternion> originalRotations = new List<Quaternion>();

    private List<Transform>  newChildTransforms = new List<Transform>();
    private List<Vector3> newPositions = new List<Vector3>();


    void Start()
    {
        foreach (Transform child in transform)
        {
            originalChildTransforms.Add(child);
            originalPositions.Add(child.localPosition);
            originalRotations.Add(child.localRotation);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ragdollActive)
        {
            //currentPosition();
            Invoke("DelayedRagdollDeactivation", 1.5f);
        }
    }

    void currentPosition()
    {
        foreach (Transform child in transform)
        {
            newChildTransforms.Add(child);
            newPositions.Add(child.localPosition);
        }
    }

    private void DelayedRagdollDeactivation()
    {
        isNotRagdoll();
    }

    public void isRagdoll()
    {
        _onRagdoll.Invoke();
        ragdollActive = true;

        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().simulated = false;
        //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        foreach (Transform child in transform)
        {
            child.GetComponent<Collider2D>().enabled = true;
            child.GetComponent<Rigidbody2D>().simulated = true;
        }

        this.GetComponent<PlayerController>().enabled = false;
    }

    public void isNotRagdoll()
    {
        ragdollActive = false;
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().simulated = true;
        //this.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        for (int i = 0; i < originalChildTransforms.Count; i++)
        {
            Transform child = originalChildTransforms[i];
            child.GetComponent<Collider2D>().enabled = false;
            child.GetComponent<Rigidbody2D>().simulated = false;
            child.localPosition = originalPositions[i];
            child.localRotation = originalRotations[i];
        }

        this.GetComponent<PlayerController>().enabled = true;
    }
}
