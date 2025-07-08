using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 50;

    float destroyTimer;

    private void Start()
    {
        //Invoke(); //Ezt is tudjuk hasznalni a idozitesre, de ez string alapu. De van a nameof(DoSomething) pl.
    }

    private void DoSomething()
    {
        Debug.Log("valami");
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        Destroy(gameObject, 3f);

        destroyTimer += Time.deltaTime;
        if (destroyTimer >= 3f)
        {
            //Destroy(gameObject);
        }

        
    }
}
