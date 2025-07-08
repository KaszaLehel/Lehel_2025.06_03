using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Vector3 a, b; //Lehet Transform is 
    //[SerializeField] Transform c, d; //Ez csak pelda, ha kell esetleg.

    [SerializeField, Range(0, 1)] float startPoint = 0.5f;

    //[SerializeField] Transform currentTarget;
    Vector3 currentTarget;

    void OnValidate()
    {
        Vector3 distance = (b - a);
        //transform.position = a + distance * startPoint;  // ugyanaz mint a Vector3.Lerp(), Ez a lerp technikailag
        Setup();
    }

    private void Start()
    {
        transform.position = a;
        currentTarget = b;
        Setup();
    }

    void Setup()
    {
        transform.position = Vector3.Lerp(a, b, startPoint);
    }


    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if(transform.position == currentTarget)
        {
            currentTarget = currentTarget == a ? b : a;
        }
    }
    void OnDrawGizmos() //OnDrawGizmosSelected()
    {
        //Ha Transform kell az if()
        if (a == null || b == null)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawSphere(a, .25f);
        Gizmos.DrawSphere(b, .25f);
        Gizmos.DrawLine(a,b);
    }
}
