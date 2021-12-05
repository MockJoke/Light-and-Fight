using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightAnimationController : MonoBehaviour
{
    private PlayerMovementHandler playerMovementHandler; 
    private CollisionDetectionHandler collisionDetectionHandler; 
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovementHandler = GetComponent<PlayerMovementHandler>();
        collisionDetectionHandler = GetComponent<CollisionDetectionHandler>(); 
        playerMovementHandler.onJump += OnJump;
        playerMovementHandler.onWalk += OnWalk;
        collisionDetectionHandler.onTouchEnemy += OnHurt;
        collisionDetectionHandler.onTouchGround += OnGround; 
    }

    void OnJump()
    {
        animator.SetBool("Jumping", true);
    }

    void OnWalk(int direction)
    {
        bool walkingRight = false;
        bool walkingLeft = false;
        switch (direction)
        {
            case 1: 
                walkingRight = true;
                break; 
            case -1:
                walkingLeft = true;
                break;
            default:
                break; 
        }
        animator.SetBool("Walking_Right", walkingRight);
        animator.SetBool("Walking_Left", walkingLeft);
    }

    void OnGround()
    {
        animator.SetBool("Jumping", false); 
    }

    void OnHurt()
    {
        animator.SetBool("Hurting", true); 
    }

    private void OnDestroy()
    {
        playerMovementHandler.onJump -= OnJump;
        playerMovementHandler.onWalk -= OnWalk;
        collisionDetectionHandler.onTouchEnemy -= OnHurt;
    }
}
