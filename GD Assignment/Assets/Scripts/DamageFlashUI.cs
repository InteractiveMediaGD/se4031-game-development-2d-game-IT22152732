using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlashUI : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    [SerializeField] private float flashAlpha = 0.28f;      // strength of flash
    [SerializeField] private float flashDuration = 0.1f;    // time before fade starts
    [SerializeField] private float fadeSpeed = 3f;          // how fast it fades out

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

        // ?? Show flash
        c.a = flashAlpha;
        flashImage.color = c;

        yield return new WaitForSeconds(flashDuration);

        // ? Smooth fade out
        while (flashImage.color.a > 0)
        {
            c = flashImage.color;
            c.a -= Time.deltaTime * fadeSpeed;
            flashImage.color = c;

            yield return null;
        }

        // Ensure fully invisible
        c.a = 0f;
        flashImage.color = c;

        currentFlash = null;
    }

    public void StrongFlash()
    {
        if (currentFlash != null)
            StopCoroutine(currentFlash);

        currentFlash = StartCoroutine(StrongFlashRoutine());
    }

    private IEnumerator StrongFlashRoutine()
    {
        Color c = flashImage.color;

        // stronger red
        c.a = 0.5f;
        flashImage.color = c;

        yield return new WaitForSecondsRealtime(0.3f);

        // fade out smoothly
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.unscaledDeltaTime;
            c.a = Mathf.Lerp(0.5f, 0f, t / 0.5f);
            flashImage.color = c;
            yield return null;
        }

        c.a = 0f;
        flashImage.color = c;

        currentFlash = null;
    }
}