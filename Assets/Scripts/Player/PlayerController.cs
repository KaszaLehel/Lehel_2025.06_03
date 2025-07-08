using NUnit.Framework.Constraints;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0)] float baseSpeed = 5f;
    [SerializeField, Min(0)] float dashSpeed = 20f;
    [SerializeField, Min(0)] float dashTime = 0.5f;
    [SerializeField, Min(0)] float dashCooldown = 2f;

    [SerializeField] Vector3 direction = Vector3.zero;
    [SerializeField] float angularSpeed = 360f;
    [SerializeField] Transform cameraTransform;

    float currentSpeed;
    float timer;

    void Update()
    {
        MoveAndDash();
    }

    #region Move And Dash
    void MoveAndDash()
    {
        currentSpeed = Mathf.Max(currentSpeed, baseSpeed);

        if(Input.GetKeyDown(KeyCode.LeftShift) && timer <= 0)
        {
            currentSpeed = dashSpeed;
            timer = dashCooldown;
        }

        timer -= Time.deltaTime;

        float deceleration = (dashSpeed - baseSpeed) / dashTime;
        currentSpeed = Mathf.MoveTowards(currentSpeed, baseSpeed, deceleration * Time.deltaTime);


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        direction = new Vector3(x, 0, z); //old direction
        Vector3 globalDirection = cameraTransform.TransformDirection(direction);
        globalDirection.y = 0;


        /*direction = (cameraTransform.right * x) + (cameraTransform.forward * z); //new direction
        direction.y = 0;*/


        transform.position += direction.normalized * currentSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion target = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, angularSpeed * Time.deltaTime);
        }
    }
    #endregion
}
