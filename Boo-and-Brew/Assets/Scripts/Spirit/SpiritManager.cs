using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiritManager : MonoBehaviour
{
    [Header("Spirit Settings")]
    [SerializeField] private List<Spirit> spiritTypes;
    [SerializeField] private List<SpiritSpawnPoint> spawnPoints;
    [SerializeField] private List<Chair> tables;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnInterval = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnSpiritIfPossible), 2f, spawnInterval);
    }

    private void SpawnSpiritIfPossible()
    {
        Chair emptyTable = GetAvailableTable();
        if (emptyTable == null) return;

        Spirit spiritData = GetRandomSpirit();
        Vector3 spawnPosition = GetRandomSpawnPoint();

        GameObject spiritObj = Instantiate(spiritData.prefab, spawnPosition, Quaternion.identity);
        SpiritController controller = spiritObj.GetComponent<SpiritController>();
        controller.MoveToTable(emptyTable);
    }

    private Chair GetAvailableTable()
    {
        foreach (var table in tables)
        {
            if (!table.IsOccupied)
                return table;
        }
        return null;
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