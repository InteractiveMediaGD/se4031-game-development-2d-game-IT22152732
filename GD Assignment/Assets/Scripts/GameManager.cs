using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int currentScore = 0;

    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    [Header("UI References")]
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private DamageFlashUI damageFlashUI;
    [SerializeField] private AudioClip damageClip;
    [SerializeField] private float damageVolume = 1.2f;

    private bool isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        currentHealth = maxHealth;
        currentScore = 0;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        UpdateHealthUI();
        UpdateScoreUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            HealPlayer(10);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            AddScore(1);
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (damageFlashUI != null)
        {
            damageFlashUI.Flash();
        }

        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip, Vector3.zero, damageVolume);
        }

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void HealPlayer(int healAmount)
    {
        if (isGameOver) return;

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        currentScore += amount;
        UpdateScoreUI();
    }

    private void UpdateHealthUI()
    {
        if (healthUI != null)
        {
            healthUI.UpdateHealthUI(currentHealth, maxHealth);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreUI != null)
        {
            scoreUI.UpdateScoreUI(currentScore);
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        if (gameOverClip != null)
        {
            AudioSource.PlayClipAtPoint(gameOverClip, Camera.main.transform.position);
        }

        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}