using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Damagable damageable = other.gameObject.GetComponent<Damagable>();  

        if(damageable != null)
        {
            damageable.Damage(damage);
        }
    }
}
