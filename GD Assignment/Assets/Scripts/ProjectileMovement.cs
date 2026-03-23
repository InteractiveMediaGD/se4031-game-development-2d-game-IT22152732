using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(1);
            }

            Destroy(other.gameObject);   // destroy enemy
            Destroy(gameObject);         // destroy projectile
        }

        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);         // projectile disappears on obstacle hit
        }
    }
}