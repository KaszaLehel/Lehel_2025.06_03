using UnityEngine;

public class Practice : MonoBehaviour
{
    private void Start()
    {
        int[] num = { 1, 2, 3, 4, 5 };
        int a = 10;
        Test3(a);
        //10 Marad az a -> Mert nem hat ki

    }

    void Test3(int a)
    {
        a++;
    }

    void Test(int[] numbers)
    {
        for(int i = 0; i< numbers.Length / 2; i++ )
        {
            numbers[i] = numbers[numbers.Length - 1 - i]; //numbers['kalap'1]
        }
    }
}


