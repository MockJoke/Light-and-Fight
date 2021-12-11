using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private BossEnemyMovementHandler bossEnemyMovementHandler;
    private BossCollisionDetectionHandler bossCollisionDetectionHandler;
    private BossAttackHandler bossAttackHandler; 
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
        bossEnemyMovementHandler = GetComponent<BossEnemyMovementHandler>();
        bossCollisionDetectionHandler = GetComponent<BossCollisionDetectionHandler>();

        GameObject attackHandler = GameObject.Find("Mouth");
        bossAttackHandler = attackHandler.GetComponent<BossAttackHandler>();
        bossEnemyMovementHandler.onHitLight += OnLight;
        bossCollisionDetectionHandler.onHurt += OnHurt;
        bossAttackHandler.onSpit += OnSpit;
    }

    void OnLight()
    {
        animator.SetTrigger("onLight"); 
    }

    void OnHurt()
    {
        animator.SetTrigger("Hurt"); 
    }

    void OnSpit()
    {
        animator.SetTrigger("onSpit");
    }

    private void OnDestroy()
    {
        bossEnemyMovementHandler.onHitLight -= OnLight;
        bossCollisionDetectionHandler.onHurt -= OnHurt;
        bossAttackHandler.onSpit -= OnSpit;
    }
}
