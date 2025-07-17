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
        if (KettleManager.Instance != null)
        {
            KettleManager.Instance.NotifyGhostGone(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Kettle"))
        {
            AudioSource.PlayClipAtPoint(AudioManager.instance.ghostPoof, transform.position);
            Destroy(gameObject);
        }
    }
}