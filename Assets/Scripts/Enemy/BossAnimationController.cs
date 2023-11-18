using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    [SerializeField] private BossEnemyMovementHandler bossEnemyMovementHandler;
    [SerializeField] private BossCollisionDetectionHandler bossCollisionDetectionHandler;
    [SerializeField] private GameObject mouth;
    [SerializeField] private BossAttackHandler bossAttackHandler; 
    [SerializeField] private Animator animator;
    
    private static readonly int onLightAnimString = Animator.StringToHash("onLight");
    private static readonly int hurtAnimString = Animator.StringToHash("Hurt");
    private static readonly int spitAnimString = Animator.StringToHash("onSpit");

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        
        if (bossEnemyMovementHandler == null)
            bossEnemyMovementHandler = GetComponent<BossEnemyMovementHandler>();
        
        if (bossCollisionDetectionHandler == null)
            bossCollisionDetectionHandler = GetComponent<BossCollisionDetectionHandler>();
        
        if (bossAttackHandler)
            bossAttackHandler = mouth.GetComponent<BossAttackHandler>();
    }

    void Start()
    {
        bossEnemyMovementHandler.onHitLight += OnLight;
        bossCollisionDetectionHandler.onHurt += OnHurt;
        bossAttackHandler.onSpit += OnSpit;
    }

    void OnLight()
    {
        animator.SetTrigger(onLightAnimString); 
    }

    void OnHurt()
    {
        animator.SetTrigger(hurtAnimString); 
    }

    void OnSpit()
    {
        animator.SetTrigger(spitAnimString);
    }

    private void OnDestroy()
    {
        bossEnemyMovementHandler.onHitLight -= OnLight;
        bossCollisionDetectionHandler.onHurt -= OnHurt;
        bossAttackHandler.onSpit -= OnSpit;
    }
}
