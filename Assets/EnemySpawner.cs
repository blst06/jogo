using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    public GameObject enemyPrefab;
    public Transform spawnPoint;

    private bool enemyAlive = false;
    private float respawnTime = 5f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnEnemy();
    }

    public void OnEnemyDied()
    {
        enemyAlive = false;
        Invoke(nameof(SpawnEnemy), respawnTime);
    }

    void SpawnEnemy()
    {
        if (!enemyAlive)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemyAlive = true;
        }
    }
}