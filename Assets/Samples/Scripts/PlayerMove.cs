using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Jump Control")]
    public float jumpHeight = 4f;
    public float jumpTime = 0.4f;
    public float horizontalJumpBoost = 1.2f;

    [Header("References")]
    public Transform groundCheck;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform attackPoint; // 👈 Drag your attack point here

    private Rigidbody2D rb;
    private bool isGrounded;
    private float initialJumpVelocity;
    private float originalScaleX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float gravity = Mathf.Abs(Physics2D.gravity.y) * rb.gravityScale;
        initialJumpVelocity = Mathf.Sqrt(2f * jumpHeight * gravity);
        jumpTime = Mathf.Max(0.1f, jumpTime);

        originalScaleX = transform.localScale.x; // This will be negative if your sprite faces left
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveInput = Input.GetAxisRaw("Horizontal");
        float targetSpeed = moveInput * moveSpeed;

        float airControl = isGrounded ? 1f : 0.8f;
        rb.velocity = new Vector2(
            Mathf.Lerp(rb.velocity.x, targetSpeed, airControl * Time.deltaTime * 15f),
            rb.velocity.y
        );

        animator.SetBool("isMove", moveInput != 0);

        if (moveInput != 0)
        {
            FlipToDirection(moveInput);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(
                rb.velocity.x * horizontalJumpBoost,
                initialJumpVelocity
            );
        }
    }

    void FlipToDirection(float moveInput)
    {
        float direction = Mathf.Sign(moveInput);

        // 👇 Invert logic: left = default
        Vector3 scale = transform.localScale;
        scale.x = originalScaleX * (direction < 0 ? 1 : -1);
        transform.localScale = scale;

        spriteRenderer.flipX = false; // Not needed anymore since scale is used

        // Flip attack point
        if (attackPoint != null)
        {
            Vector3 atkPos = attackPoint.localPosition;
            atkPos.x = Mathf.Abs(atkPos.x) * (direction < 0 ? -1 : 1);
            attackPoint.localPosition = atkPos;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}


