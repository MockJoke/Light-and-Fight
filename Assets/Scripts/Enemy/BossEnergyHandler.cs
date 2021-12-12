using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BossEnergyHandler : MonoBehaviour
{
    public Image energyBar;
    public GameObject victoryScreen; 
    private BossCollisionDetectionHandler collisionDetectionHandler;

    void Start()
    {
        collisionDetectionHandler = GetComponent<BossCollisionDetectionHandler>(); 
        collisionDetectionHandler.onHurt += UpdateBar;    
    }

    void UpdateBar()
    {
        energyBar.fillAmount -= 0.5f; 
        if(energyBar.fillAmount <= 0)
        {
            victoryScreen.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        collisionDetectionHandler.onHurt -= UpdateBar;
    }
}
