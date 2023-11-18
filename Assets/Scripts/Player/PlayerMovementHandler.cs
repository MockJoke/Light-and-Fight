using UnityEngine;
using System; 

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Movement Variables")]
    [SerializeField] private float speed = 10; 
    [SerializeField] private float jumpForce = 10;
    [HideInInspector] public int currentDirection = 1; 
    
    [Header("Input Movement Controls")] 
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode jump;

    public Action onJump; 
    public Action<int> onWalk;

    void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
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
            rb.velocity = Vector2.up * jumpForce; 
            onJump?.Invoke(); 
        }
    }
}
