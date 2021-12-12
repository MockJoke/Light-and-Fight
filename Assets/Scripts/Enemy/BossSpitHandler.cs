using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitHandler : MonoBehaviour
{
    public GameObject playerLight;

    public float speed = 2f;
    public float lifeTime = 2f; 

    void Update()
    {
        if(playerLight != null)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerLight.transform.position, move); 
        }        
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0) 
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player_Lighter")) 
            Destroy(gameObject); 
    }
}
