using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kettle : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;

    public Transform CurrentTarget { get; private set; }

    private void Update()
    {
        if (CurrentTarget == null || !CurrentTarget.gameObject.activeInHierarchy)
        {
            KettleManager.Instance.AssignTarget(this);
        }

        if (CurrentTarget != null)
        {
            MoveTowardsTarget();
        }
    }

    public void SetTarget(Transform target)
    {
        CurrentTarget = target;
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (CurrentTarget.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}