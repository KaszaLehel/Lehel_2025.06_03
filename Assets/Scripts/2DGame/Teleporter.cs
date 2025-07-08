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
        Rect cameraRect = mainCamera.GetCameraRect(); // Utility.GetCameraRect(mainCamera);
        Rect objectRect = myCollider.GetObjectRect(); // Utility.GetObjectRect(myCollider);

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

    


    private void OnDrawGizmos()
    {
        if(mainCamera == null || myCollider == null)
        {
            return;
        }

        Rect cameraRect = Utility.GetCameraRect(mainCamera);
        Rect objectRect = Utility.GetObjectRect(myCollider);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(cameraRect.center, cameraRect.size);
        Gizmos.DrawWireCube(objectRect.center, objectRect.size);
    }
}
