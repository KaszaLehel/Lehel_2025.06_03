using UnityEngine;

public class HF0721 : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] float speed = 1;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Transform closest = Closest(currentPosition, transforms);

        if (closest != null)
        {
            transform.position = Vector3.MoveTowards(
                currentPosition,
                closest.position,
                speed * Time.deltaTime);
        }
    }

    Transform Closest(Vector3 selfPosition, Transform[] transforms)
    {
        if (transforms == null || transforms.Length == 0)
            return null;
        
        if (transforms.Length == 1)
            return transforms[0];

        Transform closest = transforms[0];
        float minDist = Vector3.Distance(selfPosition, transforms[0].position);
        
        for (int index = 1; index < transforms.Length; index++)
        {
            Transform t = transforms[index];
            float dist = Vector3.Distance(selfPosition, t.position);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        return closest;
    }

    void OnDrawGizmos()
    {
        Vector3 positon = transform.position;
        Transform closest = Closest(positon, transforms);
        if (closest != null)
        {
            Gizmos.DrawLine(positon, closest.position);
         } 
    }
}


