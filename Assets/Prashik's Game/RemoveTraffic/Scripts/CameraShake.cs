using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude; // X direction shake
            float z = Random.Range(-1f, 1f) * magnitude; // Z direction shake

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y, originalPosition.z + z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition; // Reset to original position
    }


}
