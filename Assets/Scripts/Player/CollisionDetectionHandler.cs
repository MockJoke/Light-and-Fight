using UnityEngine;
using System; 

public class CollisionDetectionHandler : MonoBehaviour
{
    public Action onTouchGround; 
    public Action onTouchEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BossEnemy") || collision.CompareTag("Spit"))
        {
            onTouchEnemy?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            onTouchGround?.Invoke();
        }
    }
}
