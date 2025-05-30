using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject); // destrói o projétil ao colidir
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Inimigo morreu!");
        EnemySpawner.instance.OnEnemyDied();
        Destroy(gameObject);
    }
}