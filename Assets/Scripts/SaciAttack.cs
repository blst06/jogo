using UnityEngine;

public class SaciAttack : MonoBehaviour
{
    public GameObject windPrefab;
    public Transform firePoint;
    private int direction = 1;
    public float windCooldown = 1f;
    private float windCooldownTimer = 0f;

    void Update()
    {
        if (windCooldownTimer > 0)
        {
            windCooldownTimer -= Time.deltaTime;
        }

        // Detecta direção horizontal do player (1 = direita, -1 = esquerda)
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
            direction = (int)Mathf.Sign(moveInput);

        // Ataque com tecla K e cooldown
        if (Input.GetKeyDown(KeyCode.K) && windCooldownTimer <= 0)
        {
            PerformWindAttack();
            windCooldownTimer = windCooldown;
        }
    }

    void PerformWindAttack()
    {
        Debug.Log("Rajada de vento!");
        Quaternion rotation = direction == 1 ? Quaternion.identity : Quaternion.Euler(0, 180f, 0);
        GameObject proj = Instantiate(windPrefab, firePoint.position, rotation);
        proj.GetComponent<WindProjectile>().SetDirection(direction);
    }
}
