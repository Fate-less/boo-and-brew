using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private InteractPrompt promptPrefab;
    [SerializeField] private UnityEvent onInteract;

    private InteractPrompt promptInstance;
    private bool isPlayerNearby = false;

    protected virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        onInteract.Invoke();
    }

    private void Start()
    {
        if (promptPrefab != null)
        {
            promptInstance = Instantiate(promptPrefab, transform.position, Quaternion.identity);
            promptInstance.SetKey(interactionKey);
            promptInstance.Hide();
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactionKey))
        {
            promptInstance?.PlayClickEffect();
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            promptInstance?.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            promptInstance?.Hide();
        }
    }
}
