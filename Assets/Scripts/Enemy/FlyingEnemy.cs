
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/*
enum EnemyState
{
    Fly,
    Wait,
    Shoot
}
*/

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float maxSpeed = 4f;
    [SerializeField] float randomRadiant = 10f;
    [SerializeField] Projectile projectile;
    [SerializeField] float smoothTime = 0.5f;
    //[SerializeField] float minWaitingTime = 2f;
    //[SerializeField] float maxWaitTime = 3f;

    void OnEnable()
    {
        StartCoroutine(EnemyMovement());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator EnemyMovement()
    {
        while(true)
        {
            Vector2 velocity = Vector2.zero;
            Vector2 targetPoint = GetInsideUnitCyrcle() * randomRadiant; //Random.insideUnitCircle * randomRadiant;
            

            while (Vector2.Distance(transform.position, targetPoint) > 0.01f) //(Vector2) transform.position != targetPoint)
            {
                transform.position = Vector2.SmoothDamp(transform.position, targetPoint, ref velocity, smoothTime, maxSpeed, Time.deltaTime); //MoveTowards
                yield return null;
            }
            //Debug.LogWarning("BOOOOMMMMMM");
            Shoot();

            yield return new WaitForSeconds(1);
        }    
    }


    void Shoot()
    {
        SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
        Vector3 direction = (player.transform.position - transform.position).normalized;

        float angle = Vector2.SignedAngle(Vector2.up, direction);
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(projectile, transform.position, rotation);


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Vector3.zero, randomRadiant);
    }



    /*
        EnemyState current = EnemyState.Wait;
        float timer;
        Vector2 targetPoint;

        void Update()
        {
            if(current == EnemyState.Wait)
            {
                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                    current = EnemyState.Fly;
                    targetPoint = Random.insideUnitCircle * randomRadiant;
                }
            }
            else if(current == EnemyState.Fly)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime * maxSpeed);
                if(Vector2.Distance(transform.position, targetPoint) == 0)
                {
                    current = EnemyState.Shoot;
                }
            }
            else if(current == EnemyState.Shoot)
            {
                Debug.LogWarning("BOOOMMM");
                timer = Random.Range(minWaitingTime, maxWaitTime);
                current = EnemyState.Wait;
            }
        }
    */

    Vector2 GetInsideUnitCyrcle()
    {
        float diatnace = Random.Range(0f, 1f);
        float angle = Random.Range(0f, 2 * Mathf.PI); //* Mathf.Deg2Rad;

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //Debug.Log(diatnace * direction);

        return Mathf.Sqrt(diatnace) * direction;
    }

}
