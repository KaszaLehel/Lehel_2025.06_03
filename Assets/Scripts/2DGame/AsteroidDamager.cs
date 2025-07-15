using UnityEngine;

public class AsteroidDamager : MonoBehaviour
{
    [SerializeField] float minDamage = 10f;
    [SerializeField] float maxDamage = 20;
    [SerializeField] float minSpeedToDamage = 5f;
    [SerializeField] float maxDamageSpeed = 20f;


    void OnCollisionEnter(Collision collision) => Damage(collision.gameObject, collision.relativeVelocity.magnitude);
    void OnCollisionEnter2D(Collision2D collision) => Damage(collision.gameObject, collision.relativeVelocity.magnitude);
  

    private void Damage(GameObject gameobject, float relativeSpeed)
    {
        if (relativeSpeed < minSpeedToDamage) return;

        if(gameObject.TryGetComponent(out Damagable damagable)) //Ez valami uj, nem muszaj a generikus jel <Damageable>
        {

            float t = Mathf.InverseLerp(minSpeedToDamage, maxDamageSpeed, relativeSpeed);
            float damage = Mathf.Lerp(minDamage, maxDamage, t);

            Debug.Log(damage); // EZ itt nem mukodik, DEbugolni kell otthon valahogy 

            damagable.Damage(damage);
        }
    }
}
