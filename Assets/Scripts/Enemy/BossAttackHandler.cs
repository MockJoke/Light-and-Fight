using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BossAttackHandler : MonoBehaviour
{
    public GameObject spitPrefab;
    public GameObject playerTarget;

    public float initialSpitTime = 4f;
    private float currentSpitTime; 

    public Action onSpit; 
   
    void Start()
    {
        spitPrefab.GetComponent<BossSpitHandler>().playerLight = playerTarget; 
        currentSpitTime = initialSpitTime;
    }

    void Update()
    {
        currentSpitTime -= Time.deltaTime;
        if (currentSpitTime <= 0)
        {
            Spit();
            currentSpitTime = initialSpitTime;
        }
    }

    void Spit()
    {
        onSpit?.Invoke();
        GameObject spit = GameObject.Instantiate(spitPrefab);

        GameObject spitContainer = GameObject.Find("SpitContainer"); 
        spit.transform.SetParent(spitContainer.transform); 

        spit.transform.position = transform.position;
        Vector3 spitDir = (playerTarget.transform.position - transform.position).normalized; 
        spit.GetComponent<BossSpitHandler>().spitDirection(spitDir); 
    }
}
