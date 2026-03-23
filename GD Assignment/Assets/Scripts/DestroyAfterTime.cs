using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.3f;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (sr != null)
        {
            Color c = sr.color;
            c.a -= Time.deltaTime * 3f;
            sr.color = c;
        }
        transform.localScale += Vector3.one * Time.deltaTime * 1.5f;
    }
}