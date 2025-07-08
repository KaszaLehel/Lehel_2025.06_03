using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] Collider2D myCollider;

    private void Awake()
    {
        mainCamera = Camera.main;
        myCollider = GetComponent<Collider2D>();
        //mainCamera = FindAnyObjectByType<Camera>();
    }

    private void FixedUpdate()
    {
        //Camera screen size 
        Rect cameraRect = GetCameraRect(mainCamera);
        Rect objectRect = GetObjectRect(myCollider);

        Vector2 p = transform.position;

        if (cameraRect.Contains(p)) return;

        Vector2 distance = p - cameraRect.center;

        if (cameraRect.xMax < objectRect.xMin) //right
        {
            transform.position += Vector3.left * (cameraRect.width + objectRect.width);
        }
        else if (cameraRect.xMin > objectRect.xMax)
        {
            transform.position += Vector3.right * (cameraRect.width + objectRect.width);
        }

        if (cameraRect.yMax < objectRect.yMin) //right
        {
            transform.position += Vector3.left * (cameraRect.height + objectRect.height);
        }
        else if (cameraRect.yMin > objectRect.yMax)
        {
            transform.position += Vector3.right * (cameraRect.height + objectRect.height);
        }
    }

    Rect GetObjectRect(Collider2D coll) { 
        Bounds bounds = coll.bounds;
        return new Rect(bounds.min, bounds.size);
    }

    Rect GetCameraRect(Camera cam)
    {
        Vector2 cameraSize = new(cam.orthographicSize * 2 * cam.aspect, cam.orthographicSize * 2);
        Vector2 cameraCenter = cam.transform.position;

        Rect cameraRect = new(cameraCenter - cameraSize / 2, cameraSize);
        return cameraRect;
    }


    private void OnDrawGizmos()
    {
        if(mainCamera == null || myCollider == null)
        {
            return;
        }

        Rect cameraRect = GetCameraRect(mainCamera);
        Rect objectRect = GetObjectRect(myCollider);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(cameraRect.center, cameraRect.size);
        Gizmos.DrawWireCube(objectRect.center, objectRect.size);
    }
}
