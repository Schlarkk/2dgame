using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public GameObject playerSprite;

    public Text dashCooldownText;

    public float movementSpeed = 5;
    public float dashSpeed = 15;
    public float dashDuration = 0.3f;
    public float dashCooldown = 2.0f; // Cooldown time for the dash ability
    public float jumpForce = 10;
    private bool canJump = true;
    private float dashTimer = 0.0f;
    private bool isDashing = false;
    private bool canDash = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        HandleDirection();

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }

        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }
        else if (!canDash && dashTimer < dashCooldown)
        {
            dashTimer += Time.deltaTime;
        }
        else if (!canDash && dashTimer >= dashCooldown)
        {
            canDash = true;
        }

        dashCooldownText.text = canDash ? "Ready" : dashTimer.ToString("0.00");

        if (canDash)
        {
            dashCooldownText.gameObject.SetActive(false);
        }
        else
        {
            dashCooldownText.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float currentSpeed = isDashing ? dashSpeed : movementSpeed;

        Vector2 movement = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(movement.x * currentSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        canJump = true;

        if (other.gameObject.CompareTag("Death"))
        {
            canJump = false;
        }
    }

    void StartDash()
    {
        isDashing = true;
        canDash = false;
        dashTimer = 0.0f;
    }

    void Dash()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer >= dashDuration)
        {
            isDashing = false;
        }
    }


    void HandleDirection()
    {
        // Use horizontal input and operate on localScale.x (not transform.x).
        // Flip by setting the sign explicitly so repeated presses don't invert scale incorrectly.
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0f)
        {
            Vector3 s = playerSprite.transform.localScale;
            s.x = -Mathf.Abs(s.x);
            playerSprite.transform.localScale = s;
        }
        else if (h > 0f)
        {
            Vector3 s = playerSprite.transform.localScale;
            s.x = Mathf.Abs(s.x);
            playerSprite.transform.localScale = s;
        }
    }
}