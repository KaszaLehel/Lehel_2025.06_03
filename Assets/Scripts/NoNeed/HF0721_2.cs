using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways] akkor is lefut az Update, ha nem vagyunk lay modban.
public class HF0721_2 : MonoBehaviour
{
    [SerializeField] List<Transform> objects;

    void Update()
    {
        if (objects == null || objects.Count <= 2)
            return;

        Vector3 start = objects[0].position;
        Vector3 end = objects[objects.Count - 1].position;

        for (int i = 1; i < objects.Count - 1; i++)
        {
            float rate = i / (float)(objects.Count - 1);
            objects[i].position = Vector3.Lerp(start, end, rate);
        }
    }





    /*
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed = 20f;            // Sebesség (egység / másodperc)
        [SerializeField] private float maxTurnSpeed = 90f;         // Max. szögsebesség (fok / másodperc)

        private void Update()
        {
            if (target == null)
                return;

            // 1. Irány a cél felé
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // 2. Forgási cél – lerakni egy célirányt (forgatási cél)
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // 3. Forgás – korlátozott szögsebességgel
            float maxDegreesThisFrame = maxTurnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxDegreesThisFrame);

            // 4. Mozgás előre (mindig előre megy)
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        */
}
