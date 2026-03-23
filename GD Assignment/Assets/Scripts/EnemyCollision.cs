using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private float hitVolume = 3f;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Collider2D enemyCollider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.TakeDamage(damageAmount);
            }

            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound, hitVolume);
            }

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }

            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
            }

            Destroy(gameObject, 0.3f);
        }
    }
}