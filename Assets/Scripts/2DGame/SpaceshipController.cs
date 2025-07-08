using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float acceleration = 20f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float angularSpeed = 360f;
    
    [SerializeField] float drag = 1f;

    Vector3 velocity;

    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -horizontal * angularSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 accelerationVector = acceleration * vertical * transform.up;

        velocity += accelerationVector * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;
    }
}
