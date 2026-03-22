using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 3f;
    [SerializeField] private float destroyX = -10f;

    private void Update()
    {
        float currentSpeed = baseMoveSpeed + (Time.timeSinceLevelLoad * 0.1f);

        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}