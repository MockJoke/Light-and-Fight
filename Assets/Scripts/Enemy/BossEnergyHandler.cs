using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BossEnergyHandler : MonoBehaviour
{
    public Image energyBar;
    [SerializeField] private GameObject victoryScreen; 
    private BossCollisionDetectionHandler collisionDetectionHandler;

    void Start()
    {
        energyBar.fillAmount = 1f; 
        collisionDetectionHandler = GetComponent<BossCollisionDetectionHandler>(); 
        collisionDetectionHandler.onHurt += UpdateBar;    
    }

    void UpdateBar()
    {
        energyBar.fillAmount -= 0.05f; 
        if(energyBar.fillAmount <= 0)
        {
            GameObject gameScreen = GameObject.Find("GameScreen");
            victoryScreen.SetActive(true);
            gameScreen.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        collisionDetectionHandler.onHurt -= UpdateBar;
    }
}
