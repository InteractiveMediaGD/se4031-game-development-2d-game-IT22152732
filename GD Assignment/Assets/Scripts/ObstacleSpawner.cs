using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacleTopPrefab;
    [SerializeField] private GameObject obstacleBottomPrefab;
    [SerializeField] private GameObject scoreTriggerPrefab;

    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float gapSize = 4.0f;

    [Header("Obstacle Size Variation")]
    [SerializeField] private float minScale = 0.2f;
    [SerializeField] private float maxScale = 0.6f;

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
        float randomScale = Random.Range(minScale, maxScale);

        Vector3 topPos = new Vector3(spawnX, randomY + gapSize, 0f);
        Vector3 bottomPos = new Vector3(spawnX, randomY - gapSize, 0f);
        Vector3 triggerPos = new Vector3(spawnX, randomY, 0f);

        GameObject topObstacle = Instantiate(obstacleTopPrefab, topPos, Quaternion.identity);
        GameObject bottomObstacle = Instantiate(obstacleBottomPrefab, bottomPos, Quaternion.identity);
        Instantiate(scoreTriggerPrefab, triggerPos, Quaternion.identity);

        topObstacle.transform.localScale = new Vector3(randomScale, randomScale, 1f);
        bottomObstacle.transform.localScale = new Vector3(randomScale, randomScale, 1f);

        SpriteRenderer topRenderer = topObstacle.GetComponent<SpriteRenderer>();
        SpriteRenderer bottomRenderer = bottomObstacle.GetComponent<SpriteRenderer>();

        if (topRenderer != null && bottomRenderer != null)
        {
            int randomIndex = Random.Range(0, 3);

            Color randomAsh;

            if (randomIndex == 0)
            {
                randomAsh = new Color(0.85f, 0.85f, 0.85f); // light gray
            }
            else if (randomIndex == 1)
            {
                randomAsh = new Color(0.65f, 0.65f, 0.65f); // medium gray
            }
            else
            {
                randomAsh = new Color(0.45f, 0.45f, 0.45f); // dark gray
            }

            topRenderer.color = randomAsh;
            bottomRenderer.color = randomAsh;
        }
    }
}