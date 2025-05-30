using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;
    [SerializeField] float projectileForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject spell = Instantiate(projectile, transform.position, quaternion.identity);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - (Vector2)transform.position;
            direction.Normalize();

            spell.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileForce;
            spell.GetComponent<TestProjectile>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
        }
    }
}
