
using System.Collections;
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
    //[SerializeField] float randomRadiant = 10f;
    [SerializeField] Projectile projectile;
    [SerializeField] float smoothTime = 0.5f;
    //[SerializeField] float minWaitingTime = 2f;
    //[SerializeField] float maxWaitTime = 3f;

    private Vector2 velocity = Vector2.zero;

    void OnEnable()
    {
        SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
        StartCoroutine(EnemyMovement(player));
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator EnemyMovement(SpaceshipController player)
    {
        while (true)
        {
            Camera mainCamera = Camera.main;
            Rect cameraRect = mainCamera.GetCameraRect(); //Utility.GetCameraRect(mainCamera);

            Vector2 targetPoint = cameraRect.GetRandomPoint(); //Utility.GetRandomPoint(cameraRect);

            //Vector2 targetPoint = GetInsideUnitCyrcle() * randomRadiant; //Random.insideUnitCircle * randomRadiant;

            while (Vector2.Distance(transform.position, targetPoint) > 0.01f) //(Vector2) transform.position != targetPoint)
            {
                transform.position = Vector2.SmoothDamp(transform.position, targetPoint, ref velocity, smoothTime, maxSpeed, Time.deltaTime); //MoveTowards

                if (player != null)
                {
                    Vector3 direction = (player.transform.position - transform.position).normalized;
                    float targetAngle = Vector2.SignedAngle(Vector2.up, direction);

                    Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360f * Time.deltaTime);
                }
                
                yield return null;
            }

            /*Shooting*/
            Instantiate(projectile, transform.position, transform.rotation);

            /* Rotate and Soot Coroutine */
            //Shoot(player);
            //StartCoroutine(RotateAndShoot());

            yield return new WaitForSeconds(1);
        }    
    }


#region IEnumerator RotateAnd Shoot
    IEnumerator RotateAndShoot()
    {
        SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
        if (player == null) yield break;

        float elapse = 0f;
        float duration = 0.3f;

        Vector3 direction = (player.transform.position - transform.position).normalized;
        float targetAngle = Vector2.SignedAngle(Vector2.up, direction);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, targetAngle);

        while (elapse < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapse / duration); //Spherical interpolacio, not Linear Interpolacio
            elapse += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;

        //Quaternion rotation = Quaternion.Euler(0, 0, targetAngle);    /*Ha akarjuk hogy a loves is lekovesse a targetet*/
        Instantiate(projectile, transform.position, endRotation);

    }
#endregion


#region Shoot and OnDrawGizmos
    void Shoot(SpaceshipController player)
    {
        //SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
        Vector3 direction = (player.transform.position - transform.position).normalized;

        float angle = Vector2.SignedAngle(Vector2.up, direction);

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Instantiate(projectile, transform.position, rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(Vector3.zero, randomRadiant);
        //Gizmos.DrawWireCube(cameraRect.center, cameraRect.size);
    }
#endregion


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
