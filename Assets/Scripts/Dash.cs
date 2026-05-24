using UnityEngine;

public class Dash : MonoBehaviour
{
   [Header("Dash Settings")]
    public float dashSpeed = 20f;       // Dash speed
    public float dashDistance = 5f;     // Dash distance
    public float dashCooldown = 2f;     // Cooldown duration

    private Rigidbody2D rb;
    private bool canDash = true;
    public bool movementEnable = true;
    private float dashDuration;
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !CollisionHandler.isDeath)
        {
            dashDuration = dashDistance / dashSpeed;
            movementEnable = false;
            StartDash();
        }
    }

    void StartDash()
    {
        canDash = false;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput == 0f)
        {
            horizontalInput = transform.localScale.x > 0 ? 1f : -1f;
        }

        animator.SetTrigger("isDash");
        rb.linearVelocity = new Vector2(horizontalInput * dashSpeed, rb.linearVelocity.y);

        Invoke(nameof(EndDash), dashDuration);
        Invoke(nameof(ResetDash), dashCooldown);
    }

    void EndDash()
    {
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        movementEnable = true;
    }

    void ResetDash()
    {
        canDash = true;
    }
}
