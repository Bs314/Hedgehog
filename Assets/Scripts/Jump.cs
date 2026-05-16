using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 10f;          // Base jump force
    public bool doubleJump = true;         // Toggle double jump
    public float runJumpMultiplier = 1.3f; // Extra force when running

    [Header("Advanced Settings")]
    public float coyoteTime = 0.2f;        // Allowed time after leaving ground
    public float jumpBufferTime = 0.2f;    // Allowed time before landing

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canDoubleJump;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ground check with OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            canDoubleJump = true;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            PerformJump();
            jumpBufferCounter = 0;
        }
        else if (jumpBufferCounter > 0 && doubleJump && canDoubleJump && !isGrounded)
        {
            PerformJump();
            canDoubleJump = false;
            jumpBufferCounter = 0;
        }
    }

    void PerformJump()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float appliedForce = jumpForce;

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            appliedForce *= runJumpMultiplier;
        }

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * appliedForce, ForceMode2D.Impulse);
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
