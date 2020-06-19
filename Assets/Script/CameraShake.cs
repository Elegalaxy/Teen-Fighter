using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitute)
    {
        Vector3 originalPos = gameObject.GetComponent<MultiCamera>().position;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = (Random.Range(-1f, 1f) * magnitute) + originalPos.x;
            float y = (Random.Range(-1f, 1f) * magnitute) + originalPos.y;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }

}
