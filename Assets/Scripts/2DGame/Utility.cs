using UnityEngine;
using System;

public static class Utility
{
    public static Rect GetObjectRect(this Collider2D coll)
    {
        Bounds bounds = coll.bounds;
        return new Rect(bounds.min, bounds.size);
    }

    public static Rect GetCameraRect(this Camera cam)
    {
        Vector2 cameraSize = new(cam.orthographicSize * 2 * cam.aspect, cam.orthographicSize * 2);
        Vector2 cameraCenter = cam.transform.position;

        Rect cameraRect = new(cameraCenter - cameraSize / 2, cameraSize);
        return cameraRect;
    }

    public static Vector2 GetRandomPoint(this Rect _rect)
    {
        float x = UnityEngine.Random.Range(_rect.xMin, _rect.xMax);
        float y = UnityEngine.Random.Range(_rect.yMin, _rect.yMax);

        return new Vector2(x, y);
    }

    public static Vector2 GetRandomPoint(this Rect _rect, System.Random random)
    {
        float x = Mathf.Lerp(_rect.xMin, _rect.xMax,  (float)random.NextDouble());   //     UnityEngine.Random.Range(_rect.xMin, _rect.xMax);
        float y = Mathf.Lerp(_rect.yMin, _rect.yMax, (float)random.NextDouble());   //      UnityEngine.Random.Range(_rect.yMin, _rect.yMax);

        return new Vector2(x, y);
    }
}
