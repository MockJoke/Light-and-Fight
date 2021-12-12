using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitHandler : MonoBehaviour
{
    [HideInInspector] public GameObject playerLight;

    public float speed = 2f;
    private Vector3 spitDir; 
    public float lifeTime = 3f;

    public void spitDirection(Vector3 dir)
    {
        this.spitDir = dir;
    }

    void Update()
    {
        if(playerLight != null)
        {
            transform.position += spitDir * speed * Time.deltaTime;
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.CompareTag("Player_Lighter")) 
            Destroy(gameObject); 
    }

}
