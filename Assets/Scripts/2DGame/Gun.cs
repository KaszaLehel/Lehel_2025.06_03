using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    [SerializeField, FormerlySerializedAs("projectile")] GameObject projectilePrototipe; //ahhoz hogy ne veszitse el a gameObject-et
    [SerializeField] Transform shotPoint;

    /*[Space(15)]
    [SerializeField] bool isGunActive;
    [SerializeField] Transform gunRight;
    [SerializeField] Transform gunLeft;*/

    private void OnValidate()
    {
        //Csak akkoe kell ha keressuk a GetComponentInChildren;  
    }

    public void Shoot()
    {
        Instantiate(projectilePrototipe, shotPoint.position, transform.rotation);
    }

    /*
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(projectilePrototipe, shotPoint.position, transform.rotation); //Uj elem, csak ezzel lehet ezt megoldani.
        }
    }
    */
}


//INTERNAL METHODUSOK
