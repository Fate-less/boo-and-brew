using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleManager : MonoBehaviour
{
    [Header("Kettle Setup")]
    public GameObject kettlePrefab;
    public Transform spawnPoint;

    private List<GameObject> activeKettles = new List<GameObject>();

    public void SpawnKettle()
    {
        if (kettlePrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Kettle Prefab or Spawn Point not assigned!");
            return;
        }

        GameObject kettle = Instantiate(kettlePrefab, spawnPoint.position, Quaternion.identity);
        activeKettles.Add(kettle);
    }

    public List<GameObject> GetActiveKettles()
    {
        return activeKettles;
    }
}