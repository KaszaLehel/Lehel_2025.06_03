using JetBrains.Annotations;
using System;
using UnityEngine;

/// <summary>
/// this is a unsigned variable
/// </summary>

public class Controller : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float radius;
    [Space(10)]
    [SerializeField, Min(0)] float area;
    [SerializeField, Min(0)] float circumferance;

    //Amikor leforditja a scriptet a Unity nem kell futtatni a jatekot.
    private void OnValidate()
    {
        /*
        area = Mathf.Pow(radius, 2) * Mathf.PI;
        circumferance = 2 * radius * Mathf.PI;
        */
        /*Mathf.Pow()
          Mathf.Sqrt() 
          Mathf.PI
          Mathf.Abs()
          Mathf.Sign()
          Mathf.Max()
          Mathf.Min()
          Mathf.Ceil()
          Mathf.Floor()
         */

        //Mathf.Clamp()

        //bool b1 = true;
        //bool b2 = false;

        bool b = 14 == (2 * 7);
        Debug.Log(b);

    }

    private void Start()
    {
        /*
        int i = 5;
        float f = 2.1f;
        bool b = true;
        string s = "alma";

        string st = s + "hello";
        string st2 = 2 + st;
        string s3 = f.ToString();
        float f2 = float.Parse(s3);

        float f3 = 12; //Implicit casting 
        int io = (int)12.2; //Explicit casting

        Debug.Log("string: " + f2);
        */
    }
}
