using UnityEngine;
using System;

public class PlayerFightAttackHandler : MonoBehaviour
{
    public Action<int> onAttack;
    
    [SerializeField] private PlayerMovementHandler playerMovementHandler;

    [SerializeField] private GameObject attackAreaRight;
    [SerializeField] private GameObject attackAreaLeft;

    void Awake()
    {
        if (playerMovementHandler == null)
            playerMovementHandler = GetComponent<PlayerMovementHandler>();
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int lastDirection = playerMovementHandler.currentDirection;
            onAttack?.Invoke(lastDirection); 
            switch(lastDirection)
            {
                case 1:
                    attackAreaRight.SetActive(true);
                    break;
                case -1:
                    attackAreaLeft.SetActive(true);
                    break; 
            }
        }
    }

    public void DisableRightAttack()
    {
        attackAreaRight.SetActive(false); 
    }
    
    public void DisableLeftAttack()
    {
        attackAreaLeft.SetActive(false); 
    }
}
