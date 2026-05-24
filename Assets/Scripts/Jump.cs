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
    private bool isDropSoundPlayed = true;
    private bool canDoubleJump;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public AudioClip dropSound;
    Animator animator;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ground check with OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded",isGrounded);

        if (isGrounded)
        {

            if(!isDropSoundPlayed)
            {
                audioSource.PlayOneShot(dropSound);
                isDropSoundPlayed = true;
            }
            
            coyoteTimeCounter = coyoteTime;
            canDoubleJump = true;
        }
        else
        {
            isDropSoundPlayed = false;
            coyoteTimeCounter -= Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !CollisionHandler.isDeath && !TimelineSignal.freezePlayer)
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

    public void ActivateDoubleJump()
    {
        doubleJump = true;
    }
}
