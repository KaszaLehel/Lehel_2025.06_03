using UnityEngine;
using UnityEngine.Animations;

public class GunController : MonoBehaviour
{

    int count = 0;
    int direction = 1;
    int pingpongIndex = 0;
    [SerializeField] Gun[] guns;

    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] ShootingType shootingType;
    [SerializeField] SpriteRenderer bullsEye;
    [SerializeField] LayerMask raycastMask;
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

        Aim();
    }

    void Aim()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, float.PositiveInfinity, raycastMask);
        

        bullsEye.enabled = hit.collider != null;

        if(hit.collider != null)
        {
            //hit
            bullsEye.transform.position = hit.point;
        }
    }
}
