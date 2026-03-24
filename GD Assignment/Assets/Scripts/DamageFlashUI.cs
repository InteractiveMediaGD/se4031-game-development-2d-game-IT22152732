using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlashUI : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    [SerializeField] private float flashAlpha = 0.28f;
    [SerializeField] private float flashDuration = 0.12f;

    private Coroutine currentFlash;

    public void Flash()
    {
        if (currentFlash != null)
        {
            StopCoroutine(currentFlash);
        }

        currentFlash = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        Color c = flashImage.color;

        c.a = flashAlpha;
        flashImage.color = c;

        yield return new WaitForSeconds(flashDuration);

        c.a = 0f;
        flashImage.color = c;

        currentFlash = null;
    }
}