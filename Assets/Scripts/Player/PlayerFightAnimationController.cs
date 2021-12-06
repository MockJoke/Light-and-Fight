using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightAnimationController : MonoBehaviour
{
    private PlayerMovementHandler playerMovementHandler;
    private CollisionDetectionHandler collisionDetectionHandler;
    private PlayerFightAttackHandler playerFightAttackHandler; 
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovementHandler = GetComponent<PlayerMovementHandler>();
        collisionDetectionHandler = GetComponent<CollisionDetectionHandler>();
        playerFightAttackHandler = GetComponent<PlayerFightAttackHandler>(); 
        playerMovementHandler.onJump += OnJump;
        playerMovementHandler.onWalk += OnWalk;
        playerFightAttackHandler.onAttack += OnAttack; 
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
     
    void OnAttack(int attackDirection)
    {
        bool attackingRight = false;
        bool attackingLeft = false;
        switch (attackDirection)
        {
            case 1:
                attackingRight = true;
                break;
            case -1:
                attackingLeft = true;
                break;
            default:
                break;
        }
        animator.SetBool("Attacking_Right", attackingRight);
        animator.SetBool("Attacking_Left", attackingLeft);
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
