using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashForce = 20f; // Kekuatan dash
    public float dashDuration = 0.2f; // Durasi dash
    public float dashCooldown = 1f; // Waktu cooldown dash

    private Rigidbody2D rb;
    private float dashTimer;
    private float cooldownTimer;
    private bool isDashing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer <= 0 && !isDashing)
        {
            StartDash();
        }

        // Durasi Dash
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                StopDash();
            }
        }
    }

    void StartDash()
{
    isDashing = true;
    dashTimer = dashDuration;
    cooldownTimer = dashCooldown;

    // Arah Dash
    float direction = Mathf.Sign(rb.velocity.x); // Mendapatkan arah dari kecepatan horizontal
    if (direction == 0)
    {
        direction = transform.localScale.x; // Menggunakan arah sprite jika tidak ada kecepatan
    }

    rb.AddForce(new Vector2(direction * dashForce, 0f), ForceMode2D.Impulse);
}

    void StopDash()
    {
        isDashing = false;
        rb.velocity = new Vector2(0, rb.velocity.y); // Menghentikan dash secara tiba-tiba
    }
}