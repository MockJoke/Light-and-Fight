using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BossEnemyMovementHandler : MonoBehaviour
{
    GameObject playerLight; 
    GameObject[] platforms;
    BoxCollider2D boxCollider;

    public Action onHitLight; 

    bool moving = true;

    public float timeToMove = 3; 
    public float platfromOffsetY = 1; 
    void Start()
    {
        playerLight = GameObject.FindGameObjectWithTag("Player_Lighter"); 
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        boxCollider = GetComponent<BoxCollider2D>();
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
    private void Move()
    {  
        //setting position of enemy at a random platform 
        GameObject gotoPlatform = platforms[UnityEngine.Random.Range(0, platforms.Length)];
        Vector2 platformPos = gotoPlatform.transform.position;
        transform.position = platformPos + (Vector2.up * platfromOffsetY);
        
        //move the enemy only when it's on light
        if(!isOnLight())
        {
            moving = false; 
        }
        else
        {
            Move(); 
        }
    }
}
