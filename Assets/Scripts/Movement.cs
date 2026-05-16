using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 5f;          
    public float accelerationTime = 0.5f; 

    private Rigidbody2D rb;
    private float acceleration; 
    private float targetSpeed;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        acceleration = maxSpeed / accelerationTime;
    }

    void Update()
    {
        
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        
        targetSpeed = moveInput * maxSpeed;

        
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
    }
}
