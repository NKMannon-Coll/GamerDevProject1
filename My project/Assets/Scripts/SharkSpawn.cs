using System.Collections;
using UnityEngine;

public class SharkSpawn : MonoBehaviour
{
    public GameObject shark;
    public Camera mainCamera; 
    public float spawnOffset = .5f; 

    void Start()
    {
        StartCoroutine(Sharks());
    }

    IEnumerator Sharks()
{
    for (;;)
    {
        Vector3 spawnPosition = GetRandomEdgePosition();
        Instantiate(shark, spawnPosition, Quaternion.identity);

        // Base spawn delay range
        float minDelay = 0.5f;
        float maxDelay = 2f;

        // Adjust delay based on score 
        float difficultyMultiplier = Mathf.Clamp(1f - (GameManager.Instance.score * 0.02f), 0.2f, 1f);
        float spawnDelay = Random.Range(minDelay, maxDelay) * difficultyMultiplier;

        yield return new WaitForSeconds(spawnDelay);
    }
}

    Vector3 GetRandomEdgePosition()
    {
        if (mainCamera == null)
            mainCamera = Camera.main; 

        Vector3 spawnPos = Vector3.zero;
        int edge = Random.Range(0, 4);
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        switch (edge)
        {
            case 0: // Top
                spawnPos = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnOffset, 0);
                break;
            case 1: // Bottom
                spawnPos = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnOffset, 0);
                break;
            case 2: // Left
                spawnPos = new Vector3(-screenBounds.x - spawnOffset, Random.Range(-screenBounds.y, screenBounds.y), 0);
                break;
            case 3: // Right
                spawnPos = new Vector3(screenBounds.x + spawnOffset, Random.Range(-screenBounds.y, screenBounds.y), 0);
                break;
        }

        return spawnPos;
    }
}
