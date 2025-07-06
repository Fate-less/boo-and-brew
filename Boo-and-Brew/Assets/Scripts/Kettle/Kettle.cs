using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Kettle : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;

    private Transform targetGhost;

    private void Update()
    {
        if (targetGhost == null || !targetGhost.gameObject.activeInHierarchy)
        {
            FindNearestGhost();
        }

        if (targetGhost != null)
        {
            MoveTowardsTarget();
        }
    }

    private void FindNearestGhost()
    {
        var ghosts = FindObjectsOfType<Ghost>();

        if (ghosts.Length == 0)
        {
            targetGhost = null;
            return;
        }

        targetGhost = ghosts
            .Select(g => g.transform)
            .OrderBy(t => Vector2.Distance(transform.position, t.position))
            .FirstOrDefault();
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (targetGhost.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}