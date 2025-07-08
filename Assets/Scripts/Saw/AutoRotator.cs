using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    [SerializeField] Vector3 angularVelocity = new Vector3(0, 450, 0);
    [SerializeField] Space rotateSpace = Space.World;

    private void Update()
    {
        transform.Rotate(angularVelocity * Time.deltaTime, rotateSpace);

        /*Vector3 euler = transform.rotation.eulerAngles;
        euler.y += angularVelocity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(euler);*/
    }

    private void OnDrawGizmos()
    {
        
    }
}

