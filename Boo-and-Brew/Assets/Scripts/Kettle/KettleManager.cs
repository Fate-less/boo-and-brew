using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleManager : MonoBehaviour
{
    [Header("Kettle Setup")]
    public GameObject kettlePrefab;
    public Transform spawnPoint;

    private List<Kettle> activeKettles = new List<Kettle>();
    private HashSet<Ghost> targetedGhosts = new HashSet<Ghost>();

    public static KettleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnKettle()
    {
        if (kettlePrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Kettle Prefab or Spawn Point not assigned!");
            return;
        }

        GameObject kettleGO = Instantiate(kettlePrefab, spawnPoint.position, Quaternion.identity);
        Kettle kettle = kettleGO.GetComponent<Kettle>();
        if (kettle != null)
        {
            activeKettles.Add(kettle);
            AssignTarget(kettle);
        }
    }

    public void AssignTarget(Kettle kettle)
    {
        if (kettle.CurrentTarget != null)
            targetedGhosts.Remove(kettle.CurrentTarget.GetComponent<Ghost>());

        Ghost[] ghosts = FindObjectsOfType<Ghost>();
        foreach (Ghost ghost in ghosts)
        {
            if (!targetedGhosts.Contains(ghost))
            {
                targetedGhosts.Add(ghost);
                kettle.SetTarget(ghost.transform);
                return;
            }
        }

        kettle.SetTarget(null);
    }

    public void NotifyGhostGone(Ghost ghost)
    {
        targetedGhosts.Remove(ghost);

        foreach (var kettle in activeKettles)
        {
            if (kettle.CurrentTarget == null)
            {
                AssignTarget(kettle);
            }
        }
    }
}