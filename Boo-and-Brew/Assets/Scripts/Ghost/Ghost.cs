using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnEnable()
    {
        GhostLightManager.RegisterGhost(this);
    }

    private void OnDisable()
    {
        GhostLightManager.UnregisterGhost(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Kettle"))
        {
            //poof vfx
            Destroy(gameObject);
        }
    }
}