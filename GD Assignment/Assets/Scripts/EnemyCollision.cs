using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int damageAmount = 15;
    [SerializeField] private int scoreOnProjectileHit = 2;
    [SerializeField] private AudioClip enemyHitClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.TakeDamage(damageAmount);
            }

            if (enemyHitClip != null)
            {
                AudioSource.PlayClipAtPoint(enemyHitClip, Camera.main.transform.position);
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("Projectile"))
        {
            if (gameManager != null)
            {
                gameManager.AddScore(scoreOnProjectileHit);
            }

            if (enemyHitClip != null)
            {
                AudioSource.PlayClipAtPoint(enemyHitClip, Camera.main.transform.position);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}