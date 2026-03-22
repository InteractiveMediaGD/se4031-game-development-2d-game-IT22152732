using UnityEngine;

public class HealthPackPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 20;
    [SerializeField] private float destroyX = -10f;
    [SerializeField] private AudioClip pickupClip;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.HealPlayer(healAmount);
            }

            if (pickupClip != null)
            {
                AudioSource.PlayClipAtPoint(pickupClip, Camera.main.transform.position);
            }

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!collected && transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}