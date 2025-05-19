using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLogic : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private PlayerMovement playerDirection;

    private enum MovementState { idle, running, jumping, falling, pushing}
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (playerDirection.moveInput > 0f)
        {
            sprite.flipX = false;
            state = MovementState.running;
        }
        else if (playerDirection.moveInput < 0f)
        {
            sprite.flipX = true;
            state = MovementState.running;
        }
        else { state = MovementState.idle; }

        if (playerDirection.rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (playerDirection.rb.velocity.y < -0.1f)
        {  
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)(state));
    }
}
