using UnityEngine;

public class CameraFollowWithDeadzone : MonoBehaviour
{
    public Transform player;              // Referência ao player
    public float deadzoneWidth = 2f;     // Largura da zona morta na horizontal (metade para cada lado)
    public float fixedHeight = 5f;        // Altura fixa da câmera no eixo Y

    private Vector3 initialCameraPos;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player não atribuído na CameraFollowWithDeadzone!");
        }
        // Posição inicial da câmera (normalmente no Start)
        initialCameraPos = new Vector3(transform.position.x, fixedHeight, transform.position.z);
        transform.position = initialCameraPos;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 camPos = transform.position;
        Vector3 playerPos = player.position;

        // Define a "zona morta" horizontal da câmera (um intervalo central)
        float leftLimit = camPos.x - deadzoneWidth;
        float rightLimit = camPos.x + deadzoneWidth;

        // Se player sair da zona morta pra direita, move a câmera pra direita
        if (playerPos.x > rightLimit)
        {
            camPos.x = playerPos.x - deadzoneWidth;
        }
        // Se player sair da zona morta pra esquerda, move a câmera pra esquerda
        else if (playerPos.x < leftLimit)
        {
            camPos.x = playerPos.x + deadzoneWidth;
        }

        // Mantém a altura fixa e a posição z fixa
        camPos.y = fixedHeight;
        camPos.z = transform.position.z;

        transform.position = camPos;
    }
}
