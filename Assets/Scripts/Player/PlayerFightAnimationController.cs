using System;
using UnityEngine;

public class PlayerFightAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerMovementHandler playerMovementHandler;
    [SerializeField] private CollisionDetectionHandler collisionDetectionHandler;
    [SerializeField] private PlayerFightAttackHandler playerFightAttackHandler; 
    [SerializeField] private Animator animator;
    
    private static readonly int jumpAnimString = Animator.StringToHash("Jumping");
    private static readonly int walkingRightAnimString = Animator.StringToHash("Walking_Right");
    private static readonly int walkingLeftAnimString = Animator.StringToHash("Walking_Left");
    private static readonly int attackingRightAnimString = Animator.StringToHash("Attacking_Right");
    private static readonly int attackingLeftAnimString = Animator.StringToHash("Attacking_Left");
    private static readonly int hurtingAnimString = Animator.StringToHash("Hurting");

    void Awake()
    {
        if (playerMovementHandler == null)
            playerMovementHandler = GetComponent<PlayerMovementHandler>();
        
        if (collisionDetectionHandler == null)
            collisionDetectionHandler = GetComponent<CollisionDetectionHandler>();
                
        if (playerFightAttackHandler == null)
            playerFightAttackHandler = GetComponent<PlayerFightAttackHandler>();
        
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Start()
    {
        playerMovementHandler.onJump += OnJump;
        playerMovementHandler.onWalk += OnWalk;
        playerFightAttackHandler.onAttack += OnAttack; 
        collisionDetectionHandler.onTouchEnemy += OnHurt;
        collisionDetectionHandler.onTouchGround += OnGround;
    }
    
    void OnDestroy()
    {
        playerMovementHandler.onJump -= OnJump;
        playerMovementHandler.onWalk -= OnWalk;
        collisionDetectionHandler.onTouchEnemy -= OnHurt;
    }

    void OnJump()
    {
        animator.SetBool(jumpAnimString, true);
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
        animator.SetBool(walkingRightAnimString, walkingRight);
        animator.SetBool(walkingLeftAnimString, walkingLeft);
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
        animator.SetBool(attackingRightAnimString, attackingRight);
        animator.SetBool(attackingLeftAnimString, attackingLeft);
    }

    void OnGround()
    {
        animator.SetBool(jumpAnimString, false);
    }

    void OnHurt()
    {
        animator.SetBool(hurtingAnimString, true);
    }
}
