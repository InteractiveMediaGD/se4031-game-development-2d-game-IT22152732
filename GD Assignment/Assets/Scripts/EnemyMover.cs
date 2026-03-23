using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float destroyX = -12f;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}