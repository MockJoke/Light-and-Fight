using UnityEngine;

public class PlayerLightAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerMovementHandler playerMovementHandler; 
    [SerializeField] private CollisionDetectionHandler collisionDetectionHandler; 
    [SerializeField] private Animator animator;
    
    private static readonly int jumpAnimString = Animator.StringToHash("Jumping");
    private static readonly int walkingRightAnimString = Animator.StringToHash("Walking_Right");
    private static readonly int walkingLeftAnimString = Animator.StringToHash("Walking_Left");
    private static readonly int hurtingAnimString = Animator.StringToHash("Hurting");
    
    void Awake()
    {
        if (playerMovementHandler == null)
            playerMovementHandler = GetComponent<PlayerMovementHandler>();
        
        if (collisionDetectionHandler == null)
            collisionDetectionHandler = GetComponent<CollisionDetectionHandler>();
        
        if (animator == null)
            animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        playerMovementHandler.onJump += OnJump;
        playerMovementHandler.onWalk += OnWalk;
        collisionDetectionHandler.onTouchEnemy += OnHurt;
        collisionDetectionHandler.onTouchGround += OnGround; 
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

    void OnGround()
    {
        animator.SetBool(jumpAnimString, false); 
    }

    void OnHurt()
    {
        animator.SetBool(hurtingAnimString, true); 
    }

    private void OnDestroy()
    {
        playerMovementHandler.onJump -= OnJump;
        playerMovementHandler.onWalk -= OnWalk;
        collisionDetectionHandler.onTouchEnemy -= OnHurt;
    }
}
