using UnityEngine;

public class GunController : MonoBehaviour
{

    int count = 0;
    int direction = 1;
    int pingpongIndex = 0;
    [SerializeField] Gun[] guns;

    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] ShootingType shootingType;
    enum ShootingType
    {
        Loop,
        SameTime,
        PingPong
    }

    void OnValidate()
    {
        guns = GetComponentsInChildren<Gun>(true);
        
    }

    void Shoot()
    {
        if(shootingType== ShootingType.Loop)
        {
            guns[count % guns.Length].Shoot();
        }
        else if(shootingType == ShootingType.SameTime)
        {
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
        else if(shootingType == ShootingType.PingPong)
        {
            guns[pingpongIndex].Shoot();
            pingpongIndex += direction;
        }
        
        count++;
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Shoot(); //Uj elem, csak ezzel lehet ezt megoldani.
        }
    }
}
