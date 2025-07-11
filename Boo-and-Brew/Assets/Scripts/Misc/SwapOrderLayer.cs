using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapOrderLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
}
