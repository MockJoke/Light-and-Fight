using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private BossEnemyMovementHandler BossEnemyMovementHandler;
    private BossCollisionDetectionHandler bossCollisionDetectionHandler;
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
        BossEnemyMovementHandler = GetComponent<BossEnemyMovementHandler>();
        bossCollisionDetectionHandler = GetComponent<BossCollisionDetectionHandler>();
        BossEnemyMovementHandler.onHitLight += OnLight;
        bossCollisionDetectionHandler.OnHurt += OnHurt; 
    }

    void OnLight()
    {
        animator.SetTrigger("")
    }

    void OnHurt()
    {

    }
}
