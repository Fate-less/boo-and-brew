using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class SpiritController : MonoBehaviour
{
    private Chair targetChair;
    private float speed = 2f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveToTable(Chair table)
    {
        targetChair = table;
        targetChair.Occupy();
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        animator.SetBool("isMoving", true);
        LookAtTable();
        while (Vector2.Distance(transform.position, targetChair.transform.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetChair.transform.position, speed * Time.deltaTime);
            yield return null;
        }
        LookAtTable();
        animator.SetBool("isMoving", false);
        targetChair.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void LookAtTable()
    {
        if (targetChair.tableObj.transform.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
}