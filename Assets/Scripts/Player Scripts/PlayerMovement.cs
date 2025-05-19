using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player components
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private SizeLogic size;
    [SerializeField] private PauseLogic pause;
    [SerializeField] private AudioSource jumpSound;

    //Lateral movement
    public float moveInput = 0f;
    [SerializeField] private float smallSpeed;
    [SerializeField] private float bigSpeed;
    private float currentSpeed;

    //Jumping
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpBufferTime;
    private float jumpBufferCounter;
    [SerializeField] private float coyoteTime;
    private float coyoteTimeCounter;

    //Ground check
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float castDistance;
    [SerializeField] private Vector2 boxSize;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (size.isBig)
        {
            currentSpeed = bigSpeed;
        }
        else { currentSpeed = smallSpeed; }

        if (!pause.isPaused)
        { moveInput = Input.GetAxisRaw("Horizontal"); }


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && !size.isBig && !pause.isPaused)
        {
            jumpBufferCounter = jumpBufferTime;
            jumpSound.Play();
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && !size.isBig && !pause.isPaused)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position- transform.up * castDistance, boxSize);
    }
}
