using UnityEngine;

public class HealthPackRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.1f;   // speed of swing
    [SerializeField] private float maxAngle = 5f;       // how much it tilts

    private void Update()
    {
        float angle = Mathf.Sin(Time.time * rotationSpeed) * maxAngle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}