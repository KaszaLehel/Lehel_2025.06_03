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

    public static float Range(this System.Random random, float minValue, float maxValue)
    {
        double d = random.NextDouble();
        return Mathf.Lerp(minValue, maxValue, (float)d);
        //float magnitude = Mathf.Lerp(minSpeed, maxSpeed, (float)d);
    }

    public static Vector2 InsideUnitCyrcle(this System.Random random)
    {
        float d = (float)random.NextDouble() * Mathf.PI * 2;
        Vector2 direction = new Vector2(Mathf.Cos(d), Mathf.Sin(d));
        float m = (float)random.NextDouble();
        return direction * m;
    }

    public static Vector2 OnUnitCyrcle(this System.Random random)
    {
        float d = (float)random.NextDouble() * Mathf.PI * 2;
        return new Vector2(Mathf.Cos(d), Mathf.Sin(d));
    }



}
