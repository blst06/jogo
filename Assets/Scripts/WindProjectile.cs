using UnityEngine;

public class WindProjectile : MonoBehaviour
{
    private int direction = 1;
    public void SetDirection(int dir)
    {
        direction = dir;
    }
    public float speed = 10f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Dano aqui depois
            Destroy(gameObject);
        }
    }
}
