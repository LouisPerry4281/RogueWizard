using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyRecieveDamage>() != null)
            {
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
