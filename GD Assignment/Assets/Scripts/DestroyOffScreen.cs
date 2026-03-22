using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    [SerializeField] private float destroyX = -10f;

    void Update()
    {
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}