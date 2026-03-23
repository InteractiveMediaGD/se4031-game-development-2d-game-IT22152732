using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float resetX = -20f;
    [SerializeField] private float startX = 20f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= resetX)
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
}