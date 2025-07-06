using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject ghostPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    [Header("Ghost Limit")]
    public int maxGhosts = 5;

    private List<GameObject> spawnedGhosts = new List<GameObject>();
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && spawnedGhosts.Count < maxGhosts)
        {
            SpawnGhost();
            timer = 0f;
        }
    }

    private void SpawnGhost()
    {
        if (spawnPoints.Length == 0 || ghostPrefab == null) return;

        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newGhost = Instantiate(ghostPrefab, randomPoint.position, Quaternion.identity);
        spawnedGhosts.Add(newGhost);

        CleanupDestroyedGhosts();
    }

    private void CleanupDestroyedGhosts()
    {
        spawnedGhosts.RemoveAll(ghost => ghost == null);
    }
}