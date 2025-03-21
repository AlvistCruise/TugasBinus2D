using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 1f; // Kecepatan gerakan
    public float jumpForce = 10f; // Kekuatan lompatan
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // // Gerakan horizontal
        // float moveInput = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // // Lompatan
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // }

        // Gerakan horizontal (impulse)
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            rb.AddForce(new Vector2(moveInput * moveForce, 0f), ForceMode2D.Impulse);
        }

        // Lompatan (impulse)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Deteksi tanah
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}