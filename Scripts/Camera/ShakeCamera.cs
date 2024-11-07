using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Duration and magnitude can be set in the Inspector for easy tweaking
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    private Vector3 originalLocalPosition;
    private Coroutine shakeCoroutine;

    private void Start()
    {
    }

    public void TriggerShake(float duration, float magnitude)
    {
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            // Apply the shake offset around the camera's original local position
            transform.localPosition = originalLocalPosition + new Vector3(offsetX, offsetY, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Reset to the original local position after shaking
        transform.localPosition = originalLocalPosition;
    }
}
