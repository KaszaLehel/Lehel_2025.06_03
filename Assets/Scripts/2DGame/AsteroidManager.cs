using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] List<Asteroid> asteroids;
    [SerializeField] int startCount = 5;
    [SerializeField] int seed;

    private void Start()
    {
        Camera cam = Camera.main;

        Rect rect = cam.GetCameraRect();

        System.Random random = new(seed);

        for (int i = 0; i < startCount; i++)
        {
            int randomIndex = random.Next(asteroids.Count-1);
            Asteroid a = asteroids[randomIndex];
            Vector3 p = rect.GetRandomPoint(random);
            Quaternion r = Quaternion.Euler(0, 0, (float)random.NextDouble() * 360);
            Instantiate(a, p, r, transform);
        }
    }


}
