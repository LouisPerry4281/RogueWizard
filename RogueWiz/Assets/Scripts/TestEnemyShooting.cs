using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform player;

    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;
    [SerializeField] float projectileForce;
    [SerializeField] float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);

        if (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, quaternion.identity);
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            spell.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
    }
}
