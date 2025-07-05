using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrewingTable : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject popupUI;
    [SerializeField] private Image brewProgressSlider;

    [Header("Brew Settings")]
    [SerializeField] private float brewTime = 5f;
    [SerializeField] private GameObject teaPrefab;

    private bool isPlayerInRange = false;
    private bool isBrewing = false;
    private PlayerBrewer player;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space) && !isBrewing)
        {
            StartCoroutine(BrewTea());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerBrewer>();
            if (player != null && !player.IsCarryingTea())
            {
                isPlayerInRange = true;
                popupUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerBrewer>() == player)
        {
            isPlayerInRange = false;
            popupUI.SetActive(false);
        }
    }

    private IEnumerator BrewTea()
    {
        isBrewing = true;
        popupUI.SetActive(false);
        brewProgressSlider.gameObject.SetActive(true);
        brewProgressSlider.fillAmount = 0f;

        float elapsed = 0f;
        while (elapsed < brewTime)
        {
            if (!isPlayerInRange) break;

            elapsed += Time.deltaTime;
            brewProgressSlider.fillAmount = elapsed / brewTime;
            yield return null;
        }

        brewProgressSlider.gameObject.SetActive(false);

        if (isPlayerInRange)
        {
            GameObject tea = Instantiate(teaPrefab);
            player.PickUpTea(tea);
        }

        isBrewing = false;
    }
}