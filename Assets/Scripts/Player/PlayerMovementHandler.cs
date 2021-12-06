using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerMovementHandler : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed = 10; 
    public float jumpForce = 10;
    [HideInInspector] public int currentDirection = 1; 

    Rigidbody2D m_Rigidbody;
    
    [Header("Input Movement Controls")] 
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public Action onJump; 
    public Action<int> onWalk; 

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        int horizontal = ReadHorizontalInput();
        if(horizontal != 0)
        {
            MoveHorizontal(horizontal); 
        }
        ReadHorizontalInput(); 
        ReadJumpInput();
    }

    private int ReadHorizontalInput()
    {
        int horizontal = 0; 
        if(Input.GetKey(left))
        {
            horizontal = -1; 
            currentDirection = horizontal;
        } 
        else if(Input.GetKey(right))
        {
            horizontal = 1;
            currentDirection = horizontal; 
        }
        onWalk?.Invoke(horizontal);
        return horizontal; 
    }

    private void MoveHorizontal(int direction)
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime; 
    }

    private void ReadJumpInput()
    {
        if(Input.GetKey(jump))
        {
            m_Rigidbody.velocity = Vector2.up * jumpForce; 
            onJump?.Invoke(); 
        }
    }
}
