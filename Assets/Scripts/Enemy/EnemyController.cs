using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] Transform followed;

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, followed.position, speed * Time.deltaTime);

        if(followed.position != transform.position)
        {
            Vector3 direction = followed.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up); //ha kihadjuk akkor is .ups
        }
        

        /* //MOVETOWARDS ugyanez
        Vector3 enemy = transform.position;
        Vector3 player = followed.position;

        Vector3 distance = (player - enemy).normalized;
        Vector3 velocity = distance * speed;
        Vector3 step = velocity * Time.deltaTime;

        float dis = (player - enemy).magnitude;

        if(step.magnitude > dis)
        {
            step = distance * dis;
        }
        
        transform.position += step;
        */
    }
}
