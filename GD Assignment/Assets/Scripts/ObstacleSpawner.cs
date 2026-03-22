using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacleTopPrefab;
    [SerializeField] private GameObject obstacleBottomPrefab;
    [SerializeField] private GameObject scoreTriggerPrefab;

    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float gapSize = 3f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        float randomY = Random.Range(-1.5f, 1.5f);

        Vector3 topPos = new Vector3(spawnX, randomY + gapSize, 0f);
        Vector3 bottomPos = new Vector3(spawnX, randomY - gapSize, 0f);
        Vector3 triggerPos = new Vector3(spawnX, randomY, 0f);

        Instantiate(obstacleTopPrefab, topPos, Quaternion.identity);
        Instantiate(obstacleBottomPrefab, bottomPos, Quaternion.identity);
        Instantiate(scoreTriggerPrefab, triggerPos, Quaternion.identity);
    }
}