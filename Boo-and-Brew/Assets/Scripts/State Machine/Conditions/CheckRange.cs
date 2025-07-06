using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : Condition
{
    [Header("Stats")]
    public float maxDetectionRange = 5f;
    public float minDetectionRange = 1f;

    private Transform player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public override bool ConditionCheck()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null) return false;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        return distance >= minDetectionRange && distance <= maxDetectionRange;
    }
}