using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    [SerializeField] float minSpeed = 1;
    [SerializeField] float maxSpeed = 2;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Damagable damagable;

    [SerializeField] Sprite[] sprites;


    Vector2 velocity;

    private void OnValidate()
    {

        rb.GetComponent<Rigidbody2D>();
        spriteRenderer.GetComponent<SpriteRenderer>();
        damagable.GetComponent<Damagable>();
    }

    private void Awake()
    {
        damagable.OnDamage += OnDamage; // C Sharp action
    }

    private void OnDestroy()
    {
        damagable.OnDamage -= OnDamage;
    }

    private void Update()
    {
        //transform.position += (Vector3)(velocity * Time.deltaTime);

        //rb.linearVelocity = random.Range(minSpeed, maxSpeed) * random.OnUnitCyrcle();
    }

    public void Setup(System.Random random)
    {
        rb.linearVelocity = random.Range(minSpeed, maxSpeed) * random.OnUnitCyrcle(); /* float * Vector2 */
    }

    private void OnDamage()
    {
        float hpRate = - (damagable.CurrentHealth / damagable.MaxHealth);
        int index = (int)hpRate * (sprites.Length);
        index = Mathf.Min(index, sprites.Length - 1);

        spriteRenderer.sprite = sprites[index];
    }
}
