using System.Collections.Generic;
using UnityEngine;

public class HF0721_2 : MonoBehaviour
{
    [SerializeField] List<Transform> objects; 
    
    void Update()
    {
        if(objects == null || objects.Count <= 2)
            return;
        
        Vector3 start = objects[0].position;
        Vector3 end = objects[objects.Count - 1].position;
        
        for (int i = 1; i < objects.Count-1; i++)
        {
			float rate = i / (float)(objects.Count - 1);
            objects[i].position = Vector3.Lerp(start, end, rate);
        }
    }
}
