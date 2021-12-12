using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BossCollisionDetectionHandler : MonoBehaviour
{
    public Action onHurt;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerAttack"))
        {
            onHurt?.Invoke(); 
        }
    }
}
