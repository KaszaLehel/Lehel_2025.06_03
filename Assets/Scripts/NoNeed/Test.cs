using System.Globalization;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] int num = 1;

    void OnLoop(string name, int count)
    {

    }

    int Abs(int i)
    {
        if(i > 0)
        {
            return i;
        }
        return (i * (-1));
    }


    void Start()
    {
        if (num % 2 == 0)
        {
            Debug.Log("paros");
        }
        else
        {
            Debug.Log("paratlan");
        }



        int i = 1;
        while (i<=10)
        {
            Debug.Log(i*i);
            i++;
        }



        for (int j = 1; j <= 100; j++)
        {
            if(j % 7 == 0)
            {
                Debug.Log(j);
            }
        }


        for (int j = 7; j <=7*100; j+=7)
        {
            Debug.Log(j);
        }


        int count = 0;
        for (int k = 0; count < 100; k++)
        {
            if (k % 7==0)
            {
                Debug.Log(k);
                count++;
            }

        }

    }

    
}
