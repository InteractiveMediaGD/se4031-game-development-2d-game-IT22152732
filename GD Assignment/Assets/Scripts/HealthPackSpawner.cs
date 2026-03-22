using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject healthPackPrefab;
    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 3f;
    [SerializeField] private float spawnInterval = 6f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnHealthPack();
            timer = 0f;
        }
    }

    private void SpawnHealthPack()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        Instantiate(healthPackPrefab, spawnPosition, Quaternion.identity);
    }
}