using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // Esquerda e direita
        float moveZ = Input.GetAxisRaw("Vertical");   // Frente e trás (profundidade)

        movement = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
}
