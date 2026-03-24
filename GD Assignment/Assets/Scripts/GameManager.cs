using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;

    [Header("Audio")]
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip damageClip;
    [SerializeField] private float damageVolume = 1.5f;

    [Header("Damage Feedback")]
    [SerializeField] private DamageFlashUI damageFlashUI;
    [SerializeField] private CameraShake cameraShake;

    private bool isGameOver = false;
    private bool isPaused = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1f;
        isGameOver = false;
        isPaused = false;
        currentHealth = maxHealth;
        currentScore = 0;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(true);

        UpdateHealthUI();
        UpdateScoreUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            TogglePause();
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        // test key
        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     TakeDamage(10);
        // }
    }

    private void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        if (isGameOver) return;

        Time.timeScale = 0f;
        isPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        if (pauseButton != null)
            pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        // Always show flash on any damage
        if (damageFlashUI != null)
            damageFlashUI.Flash();

        // Always play damage sound on any damage
        if (damageClip != null && audioSource != null)
            audioSource.PlayOneShot(damageClip, damageVolume);

        // Normal hit shake
        if (currentHealth > 0)
        {
            if (cameraShake != null)
                cameraShake.StartShake(0.22f, 0.28f, 2.5f);
        }
        else
        {
            // Death hit: stronger flash + stronger shake + game over sound
            isGameOver = true;

            if (damageFlashUI != null)
                damageFlashUI.Flash();

            if (cameraShake != null)
                cameraShake.StartShake(0.55f, 0.40f, 5f);

            if (gameOverText != null)
                gameOverText.SetActive(true);

            if (gameOverClip != null)
                AudioSource.PlayClipAtPoint(gameOverClip, Camera.main.transform.position);

            StartCoroutine(FinalGameOverFreeze());
        }
    }

    private IEnumerator FinalGameOverFreeze()
    {
        yield return new WaitForSecondsRealtime(0.55f);
        Time.timeScale = 0f;
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
            healthUI.UpdateHealthUI(currentHealth, maxHealth);
    }

    private void UpdateScoreUI()
    {
        if (scoreUI != null)
            scoreUI.UpdateScoreUI(currentScore);
    }
}