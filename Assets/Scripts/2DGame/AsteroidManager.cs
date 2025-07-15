using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] List<Asteroid> asteroids;
    [SerializeField] int startCount = 5;
    [SerializeField] int seed;
    [SerializeField] float minDistanceFromCameraCenter;

    private void Start()
    {
        Camera cam = Camera.main;

        Rect rect = cam.GetCameraRect();

        System.Random random = new(seed);

        for (int i = 0; i < startCount; i++)
        {
            int randomIndex = random.Next(asteroids.Count-1);
            Asteroid asteroidPrefab = asteroids[randomIndex];

            Vector3 p;

            do
            {
                p = rect.GetRandomPoint(random);

            } while (Vector2.Distance(p, rect.center) < minDistanceFromCameraCenter);

            
            Quaternion r = Quaternion.Euler(0, 0, (float)random.NextDouble() * 360);
            Asteroid newAsteroid = Instantiate(asteroidPrefab, p, r, transform);

            newAsteroid.Setup(random); //EZ Dependency injection
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Camera.main.GetCameraRect().center, minDistanceFromCameraCenter);
    }

}
