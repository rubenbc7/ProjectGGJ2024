using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float moveSpeed = 10f;                
    public float acceleration = 5f;             
    public AudioClip[] footstepSounds;          


    private Rigidbody2D rb;
    private AudioSource audioSource;
    private float currentSpeed;
    private float minSpeedForFootsteps;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MovePlayer();
        PlayFootstepSounds();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float targetSpeed = horizontalInput * moveSpeed;

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.fixedDeltaTime * acceleration);
        AnimState(currentSpeed);

        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        if (horizontalInput > 0)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
    }

    private void PlayFootstepSounds()
    {
        if (Mathf.Abs(currentSpeed) > minSpeedForFootsteps && IsGrounded())
        {
            if (!audioSource.isPlaying)
            {
                AudioClip footstepClip = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepClip);
            }
        }
    }

    public bool IsGrounded()
    {
        float raycastDistance = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance);

        return hit.collider != null;
    }

    void AnimState(float speed)
    {
        Animator animator = this.GetComponent<Animator>();
        if(speed != 0)
        {
            animator.Play("walk_player");
        }
        else
        {
            animator.Play("idle_player");
        }
    }

}
