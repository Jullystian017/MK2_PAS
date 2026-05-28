using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Movement
    public float speed = 5f;
    public float jumpForce = 7f;

    // Fall limit
    public float fallLimit = -10f;

    // Respawn point
    Vector3 respawnPoint;

    // Score
    public int score = 0;
    public TextMeshProUGUI scoreText;

    // Level text
    public TextMeshProUGUI levelText;

    // Health
    public int health = 3;

    // Heart UI
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Panels
    public GameObject gameOverPanel;
    public GameObject finishPanel;

    // Damage cooldown
    public float damageCooldown = 1f;

    // Audio
    public AudioSource audioSource;

    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public AudioClip enemyDeadSound;
    public AudioClip finishSound;

    // Components
    Rigidbody2D rb;

    // Ground check
    bool isGrounded;

    // Anti spam damage
    bool isDead = false;
    bool canTakeDamage = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Simpan posisi awal player
        respawnPoint = transform.position;

        UpdateScoreText();
        UpdateHeartUI();

        // Hide game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Hide finish panel
        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
        }

        // Show level text
        if (levelText != null)
        {
            levelText.gameObject.SetActive(true);

            levelText.text =
                SceneManager.GetActiveScene().name;

            Invoke("HideLevelText", 3f);
        }
    }

    void Update()
    {
        // Kalau mati stop gerak
        if (isDead) return;

        // Gerak
        float move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity =
            new Vector2(move * speed, rb.linearVelocity.y);

        // Lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity =
                new Vector2(rb.linearVelocity.x, jumpForce);

            isGrounded = false;

            // Sound jump
            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        // Jatuh dari map
        if (transform.position.y < fallLimit)
        {
            TakeDamage();

            // Respawn kalau belum mati
            if (!isDead)
            {
                transform.position = respawnPoint;

                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    // Ground detect
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Keluar ground
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Trigger detect
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        // Coin / Gold
        if (other.CompareTag("Coin"))
        {
            score += 10;

            UpdateScoreText();

            // Sound coin
            if (coinSound != null)
            {
                audioSource.PlayOneShot(coinSound);
            }

            Destroy(other.gameObject);
        }

        // Spike
        if (other.CompareTag("Spike"))
        {
            TakeDamage();
        }

        // Enemy
        if (other.CompareTag("Enemy"))
        {
            // Kalau injak kepala enemy
            if (transform.position.y >
                other.transform.position.y + 0.5f)
            {
                // Sound enemy dead
                if (enemyDeadSound != null)
                {
                    audioSource.PlayOneShot(enemyDeadSound);
                }

                Destroy(other.gameObject);

                // Bounce
                rb.linearVelocity =
                    new Vector2(rb.linearVelocity.x, jumpForce);

                // Tambah score
                score += 20;

                UpdateScoreText();
            }
            else
            {
                TakeDamage();
            }
        }

        // Flag
        if (other.CompareTag("Flag"))
        {
            string currentScene =
                SceneManager.GetActiveScene().name;

            // Kalau level terakhir
            if (currentScene == "level3")
            {
                FinishGame();
            }
            else
            {
                int nextSceneIndex =
                    SceneManager.GetActiveScene().buildIndex + 1;

                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }

    // Damage system
    void TakeDamage()
    {
        // Anti spam damage
        if (!canTakeDamage) return;

        canTakeDamage = false;

        health--;

        Debug.Log("Health: " + health);

        // Sound hurt
        if (hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        UpdateHeartUI();

        // Mati
        if (health <= 0)
        {
            GameOver();
        }
        else
        {
            // Reset damage setelah cooldown
            Invoke("ResetDamage", damageCooldown);
        }
    }

    // Reset damage cooldown
    void ResetDamage()
    {
        canTakeDamage = true;
    }

    // Hide level text
    void HideLevelText()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(false);
        }
    }

    // Game over
    void GameOver()
    {
        isDead = true;

        Debug.Log("GAME OVER");

        // Stop gerak player
        rb.linearVelocity = Vector2.zero;

        // Munculin panel game over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Stop game
        Time.timeScale = 0f;
    }

    // Finish game
    void FinishGame()
    {
        isDead = true;

        Debug.Log("YOU WIN");

        // Stop gerak player
        rb.linearVelocity = Vector2.zero;

        // Sound finish
        if (finishSound != null)
        {
            audioSource.PlayOneShot(finishSound);
        }

        // Munculin finish panel
        if (finishPanel != null)
        {
            finishPanel.SetActive(true);
        }

        // Stop game
        Time.timeScale = 0f;
    }

    // Tombol restart
    public void RestartGame()
    {
        Debug.Log("RESTART");

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    // Tombol home
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("mainmenu");
    }

    // Update score UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Gold: " + score;
        }
    }

    // Update heart UI
    void UpdateHeartUI()
    {
        if (heart1 != null)
            heart1.SetActive(health >= 1);

        if (heart2 != null)
            heart2.SetActive(health >= 2);

        if (heart3 != null)
            heart3.SetActive(health >= 3);
    }
}