using UnityEngine;
using UnityEngine.UI; 

public class PlayerEnergyHandler : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject gamePlayScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private CollisionDetectionHandler collisionDetectionHandler;

    void Awake()
    {
        if (collisionDetectionHandler == null)
            collisionDetectionHandler = GetComponent<CollisionDetectionHandler>();
    }

    void Start()
    {
        energyBar.fillAmount = 1f;
        collisionDetectionHandler.onTouchEnemy += UpdateBar; 
    }

    void UpdateBar()
    {
        energyBar.fillAmount -= 0.02f;
        
        if(energyBar.fillAmount <= 0)
        {
            gameOverScreen.SetActive(true);
            gamePlayScreen.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        collisionDetectionHandler.onTouchEnemy -= UpdateBar;
    }
}
