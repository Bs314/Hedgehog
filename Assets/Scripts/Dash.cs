using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
     [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashCooldown = 2f;

    private Rigidbody2D rb;

    private bool canDash = true;
    private bool isDashing = false;

    private Vector2 dashDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Shift basınca dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dassh());
        }
    }

    private IEnumerator Dassh()
    {
        canDash = false;
        isDashing = true;

        // Hareket yönünü al
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        dashDirection = new Vector2(moveX, moveY).normalized;

        // Eğer input yoksa karakterin baktığı yön
        if (dashDirection == Vector2.zero)
        {
            dashDirection = Vector2.right * transform.localScale.x;
        }

        // Dash süresi = mesafe / hız
        float dashTime = dashDistance / dashSpeed;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashTime);

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = originalGravity;

        isDashing = false;

        // Cooldown
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
