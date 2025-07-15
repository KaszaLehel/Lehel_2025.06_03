using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float acceleration = 20f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float angularSpeed = 360f;
    [SerializeField] float drag = 1f;
    [SerializeField] Rigidbody2D rbPlayer;

    //Vector3 velocity;

    void Update()
    {
        //transform.position += velocity * Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float rotation = -horizontal * angularSpeed * Time.deltaTime;
        rbPlayer.rotation += rotation; //2D rotation egy float;

        //transform.Rotate(0, 0, -horizontal * angularSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 accelerationVector = acceleration * vertical * transform.up;

        Vector2 velocity = rbPlayer.linearVelocity;

        velocity += accelerationVector * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector2 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;

        rbPlayer.linearVelocity = velocity;
    }
}
