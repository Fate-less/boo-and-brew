using UnityEngine;
using System.Collections;

public class SpiritController : MonoBehaviour
{
    private Chair targetTable;
    private float speed = 2f;

    public void MoveToTable(Chair table)
    {
        targetTable = table;
        targetTable.Occupy();
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (Vector2.Distance(transform.position, targetTable.transform.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetTable.transform.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}