using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager instance;

    [Header("Spirit Settings")]
    [SerializeField] private List<Spirit> spiritTypes;
    [SerializeField] private List<SpiritSpawnPoint> spawnPoints;
    [SerializeField] private List<Chair> chairs;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnInterval = 5f;
    private bool isRunning = false;

    private void Start()
    {
        instance = this;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        isRunning = true;
        yield return new WaitForSeconds(2f);

        while (isRunning)
        {
            SpawnSpiritIfPossible();

            float timer = 0f;
            while (timer < spawnInterval)
            {
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }

    public void SetSpawnInterval(float newInterval)
    {
        spawnInterval = newInterval;
    }

    public float GetSpawnInterval()
    {
        return spawnInterval;
    }

    private void SpawnSpiritIfPossible()
    {
        Chair emptyTable = GetAvailableChairs();
        if (emptyTable == null) return;

        Spirit spiritData = GetRandomSpirit();
        Vector3 spawnPosition = GetRandomSpawnPoint();

        GameObject spiritObj = Instantiate(spiritData.prefab, spawnPosition, Quaternion.identity);
        SpiritController controller = spiritObj.GetComponent<SpiritController>();
        controller.MoveToTable(emptyTable);
        controller.transform.SetParent(emptyTable.transform);
    }

    private Chair GetAvailableChairs()
    {
        List<Chair> availableChairs = new List<Chair>();

        foreach (var chair in chairs)
        {
            if (!chair.IsOccupied)
                availableChairs.Add(chair);
        }
        if (availableChairs.Count == 0)
            return null;
        return availableChairs[Random.Range(0, availableChairs.Count)];
    }

    private Spirit GetRandomSpirit()
    {
        return spiritTypes[Random.Range(0, spiritTypes.Count)];
    }

    private Vector3 GetRandomSpawnPoint()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        return point.transform.position;
    }
}