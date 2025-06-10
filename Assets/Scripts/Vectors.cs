using UnityEngine;

public class Vectors : MonoBehaviour
{
    void OnValidate()
    {
        Vector2 v1 = new Vector2(2, 5);
        Vector3 v2 = new Vector3(2, 5, 10);

        float l = v2.magnitude; // A vektor hossza
        float k = v2.sqrMagnitude; // ugyanaz de ez optimalizalas.
    }
}
