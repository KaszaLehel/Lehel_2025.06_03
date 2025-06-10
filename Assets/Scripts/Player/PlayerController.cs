using NUnit.Framework.Constraints;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0)] float speed = 5f;
    [SerializeField] Vector3 direction = Vector3.right;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        direction = new Vector3(x, 0, z);

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
