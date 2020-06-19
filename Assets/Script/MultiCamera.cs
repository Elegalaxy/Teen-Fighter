using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCamera : MonoBehaviour
{
    public List<Transform> targerts;
    public float smoothTime = 0.1f;
    public Vector3 offset;
    Vector3 velocity;
    public GameObject grenade;
    public Vector3 position;
    private void LateUpdate()
    {
        if (targerts.Count == 0)
        {
            return;
        }
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        position = newPosition;
    }

    Vector3 GetCenterPoint()
    {
        if(targerts.Count == 1)
        {
            return targerts[0].position;
        }

        var bounds = new Bounds(targerts[0].position, Vector3.zero);
        for (int i = 0; i < targerts.Count; i++)
        {
            bounds.Encapsulate(targerts[i].position);
        }
        return bounds.center;
    }
}
