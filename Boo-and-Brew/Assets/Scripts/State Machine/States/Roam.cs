using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Roam : State
{
    [Header("Stats")]
    public float moveSpeed = 3f;
    public float roamRadius = 5f;
    public float roamTime = 3f;

    private Vector2 roamTarget;
    private Vector3 originalScale;
    private float roamTimer;
    private Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        PickNewRoamTarget();
    }

    protected override void Update()
    {
        Roaming();
    }

    private void Roaming()
    {
        roamTimer -= Time.deltaTime;
        if (roamTimer <= 0 || Vector2.Distance(transform.position, roamTarget) < 0.5f)
        {
            PickNewRoamTarget();
        }

        Vector2 direction = (roamTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (direction.x != 0)
        {
            transform.localScale = new Vector3(-Mathf.Sign(direction.x) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }

    private void PickNewRoamTarget()
    {
        Vector2 randomOffset = Random.insideUnitCircle * roamRadius;
        roamTarget = (Vector2)transform.position + randomOffset;
        roamTimer = roamTime;
    }
}