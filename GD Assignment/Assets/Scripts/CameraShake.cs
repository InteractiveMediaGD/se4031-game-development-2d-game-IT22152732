using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeMagnitude = 0.22f;
    [SerializeField] private float rotationMagnitude = 2.5f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Coroutine currentShake;

    private void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    public void StartShake(float duration, float magnitude, float rotation)
    {
        if (currentShake != null)
        {
            StopCoroutine(currentShake);
        }

        currentShake = StartCoroutine(ShakeRoutine(duration, magnitude, rotation));
    }

    private IEnumerator ShakeRoutine(float duration, float magnitude, float rotation)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float currentMagnitude = Mathf.Lerp(magnitude, 0f, elapsed / duration);
            float currentRotation = Mathf.Lerp(rotation, 0f, elapsed / duration);

            float x = Random.Range(-1f, 1f) * currentMagnitude;
            float y = Random.Range(-1f, 1f) * currentMagnitude;
            float z = Random.Range(-1f, 1f) * currentRotation;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, z);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
        currentShake = null;
    }
}