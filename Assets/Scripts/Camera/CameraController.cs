using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.LookAt(target);
        //transform.rotation = Quaternion.LookRotation(target.position, Vector3.up);
    }
}
