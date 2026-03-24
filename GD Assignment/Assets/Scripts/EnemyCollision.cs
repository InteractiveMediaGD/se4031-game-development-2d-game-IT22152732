using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    private SpriteRenderer spriteRenderer;
    private Collider2D enemyCollider;

    private void Awake()
    {
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