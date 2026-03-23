using UnityEngine;

public class CloudFloat : MonoBehaviour
{
    private float startY;
    public float floatAmount = 0.3f;
    public float floatSpeed = 1f;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}