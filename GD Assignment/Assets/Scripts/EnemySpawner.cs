using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 3f;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 5f;

    [Header("Difficulty Settings")]
    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float difficultyIncreaseRate = 0.2f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

        // ?? Increase difficulty over time
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval -= difficultyIncreaseRate * Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}