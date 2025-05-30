using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject defeatedText; // arraste aqui o seu objeto "Inimigo derrotado"

    void Start()
    {
        currentHealth = maxHealth;
        defeatedText.SetActive(false); // começa invisível
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        defeatedText.SetActive(true);  // mostra o texto
        Destroy(gameObject);            // destrói o inimigo
    }
}