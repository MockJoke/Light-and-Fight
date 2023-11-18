using System.Collections;
using UnityEngine;
using System;

public class BossEnemyMovementHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerLight; 
    [SerializeField] private CircleCollider2D circleCollider;
    
    private GameObject[] platforms;
    private bool moving = true;
    
    public Action onHitLight; 

    [SerializeField] private float timeToMove = 3; 
    [SerializeField] private float platformOffsetY = 1;

    void Awake()
    {
        if (playerLight == null)
            playerLight = GameObject.FindGameObjectWithTag("Player_Lighter");
        
        if (circleCollider == null)
            circleCollider = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        
        Move();  
    }

    void FixedUpdate()
    {
        if(isOnLight())
        {
            if(!moving)
            {
                moving = true;
                StartCoroutine(DelayedMove(timeToMove)); 
            }
        }
    }

    private bool isOnLight()
    {
        Vector2 target = playerLight.transform.position - transform.position;
        int enemyLayerMask = ~(LayerMask.GetMask("Enemy"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target, 1000, enemyLayerMask); 
        bool onLight = true;
        if(hit)
        {
            onLight = hit.transform.gameObject.CompareTag(playerLight.tag); 
            if(onLight)
            {
                onHitLight?.Invoke(); 
            }
        }
        return onLight; 
    }
    
    IEnumerator DelayedMove(float time)
    {
        yield return new WaitForSeconds(time);
        Move();  
    }

    Vector2 getValidPosition()
    {
        GameObject gotoPlatform = platforms[UnityEngine.Random.Range(0, platforms.Length)];
        Vector2 platformPos = gotoPlatform.transform.position;

        bool isIntersecting = Physics2D.OverlapCircle(platformPos + (Vector2.up * platformOffsetY), 0.1f);
        if(isIntersecting)
        {
            return getValidPosition();
        }
        else
        {
            return platformPos; 
        }
    } 

    private void Move()
    {
        transform.position = getValidPosition() + (Vector2.up * platformOffsetY);
        moving = false;
        
        ////move the enemy only when it's on light
        //if (!isOnLight())
        //{ 
        //    moving = false;
        //}
        //else
        //{
        //    transform.position = getValidPosition() + (Vector2.up * platfromOffsetY);
        //    //moving = true; 
        //    //Move(platformPos);
        //}        
    }
}
