using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Rigidbody2D player;               // Player's Rigidbody
    public Rigidbody2D hammer;               // Hammer's Rigidbody
    public float hammerLength = 2f;          // Distance from player to hammer's pivot
    public float moveForce = 500f;           // Force applied to move the hammer
    public float recoilForce = 300f;         // Recoil force applied to the player

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        hammer.bodyType = RigidbodyType2D.Dynamic; // Ensure the hammer reacts to physics
    }

    void Update()
    {
        MoveHammer();
    }

    // Moves the hammer based on the mouse position
    void MoveHammer()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - player.position).normalized;

        // Apply force to the hammer towards the mouse position
        hammer.AddForce(direction * moveForce * Time.deltaTime);

        // Optional: Rotate the hammer visually to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        hammer.rotation = angle + 90f;
    }

    // Handle physics-based recoil when hammer hits objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 1f) // Only apply recoil on strong impacts
        {
            Vector2 recoilDirection = (hammer.position - player.position).normalized;
            player.AddForce(-recoilDirection * recoilForce, ForceMode2D.Impulse);
        }

        // Simple enemy destruction on impact
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
