using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerEnergyHandler : MonoBehaviour
{
    public Image energyBar;
    [SerializeField] private GameObject gameoverScreen; 
    private CollisionDetectionHandler collisionDetectionHandler;

    void Start()
    {
        energyBar.fillAmount = 1f;
        collisionDetectionHandler = GetComponent<CollisionDetectionHandler>();
        collisionDetectionHandler.onTouchEnemy += UpdateBar; 
    }

    void UpdateBar()
    {
        energyBar.fillAmount -= 0.02f; 
        if(energyBar.fillAmount <= 0)
        {
            GameObject gameScreen = GameObject.Find("GameScreen"); 
            gameoverScreen.SetActive(true);
            gameScreen.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        collisionDetectionHandler.onTouchEnemy -= UpdateBar;
    }
}
