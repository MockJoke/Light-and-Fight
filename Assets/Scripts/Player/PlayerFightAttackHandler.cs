using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerFightAttackHandler : MonoBehaviour
{
    private PlayerMovementHandler playerMovementHandler;
    public Action<int> onAttack;

    public GameObject attackAreaRight;
    public GameObject attackAreaLeft; 

    private void Start()
    {
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
