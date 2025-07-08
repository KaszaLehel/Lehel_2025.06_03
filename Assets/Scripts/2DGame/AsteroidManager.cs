using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] List<Asteroid> asteroids;
    [SerializeField] int startCount = 5;

    private void Start()
    {
        Camera cam = Camera.main;

        Rect rect = cam.GetCameraRect();

        for (int i = 0; i < startCount; i++)
        {
            Asteroid a = asteroids[Random.Range(0, asteroids.Count)];
            Vector3 p = rect.GetRandomPoint();
            Quaternion r = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            Instantiate(a, p, r, transform);
        }
    }


}
