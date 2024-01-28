using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private UnityEvent _onRagdoll;
    private bool ragdollActive = false;
    private List<Transform> childTransforms = new List<Transform>();
    private List<Vector3> originalPositions = new List<Vector3>();
    private List<Quaternion> originalRotations = new List<Quaternion>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            childTransforms.Add(child);
            originalPositions.Add(child.localPosition);
            originalRotations.Add(child.localRotation);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ragdollActive)
        {
            Invoke("DelayedRagdollDeactivation", 1f);
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
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        foreach (Transform child in transform)
        {
            child.GetComponent<Collider2D>().enabled = true;
            child.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    public void isNotRagdoll()
    {
        ragdollActive = false;
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 1;

        for (int i = 0; i < childTransforms.Count; i++)
        {
            Transform child = childTransforms[i];
            child.GetComponent<Collider2D>().enabled = false;
            child.GetComponent<Rigidbody2D>().simulated = false;
            child.localPosition = originalPositions[i];
            child.localRotation = originalRotations[i];
        }
    }
}
