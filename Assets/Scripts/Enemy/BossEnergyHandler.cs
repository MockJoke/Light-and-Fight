using UnityEngine;
using UnityEngine.UI; 

public class BossEnergyHandler : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject victoryScreen; 
    [SerializeField] private BossCollisionDetectionHandler collisionDetectionHandler;

    void Awake()
    {
        if (collisionDetectionHandler == null)
            collisionDetectionHandler = GetComponent<BossCollisionDetectionHandler>();
    }

    void Start()
    {
        energyBar.fillAmount = 1f; 
        collisionDetectionHandler.onHurt += UpdateBar;    
    }
    
    void OnDestroy()
    {
        collisionDetectionHandler.onHurt -= UpdateBar;
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
}
