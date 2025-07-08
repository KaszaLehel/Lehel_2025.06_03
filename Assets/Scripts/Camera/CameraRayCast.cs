using UnityEngine;

public class CameraRayCast : MonoBehaviour
{

    private void Update()
    {

        
        Vector2 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
