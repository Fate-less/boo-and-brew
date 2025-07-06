using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractPrompt : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Image keyBackground;

    private bool isVisible = false;
    private Coroutine fadeRoutine;

    public void SetKey(KeyCode key)
    {
        promptText.text = $"Press <b>{key}</b> to Interact";
    }

    public void Show()
    {
        if (isVisible) return;
        isVisible = true;
        FadeTo(1f);
    }

    public void Hide()
    {
        if (!isVisible) return;
        isVisible = false;
        FadeTo(0f);
    }

    public void PlayClickEffect()
    {
        if (keyBackground != null)
            StartCoroutine(ClickFlash());
    }

    private void FadeTo(float targetAlpha)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeCanvas(targetAlpha));
    }

    private IEnumerator FadeCanvas(float targetAlpha)
    {
        float duration = 0.2f;
        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetAlpha;
    }

    private IEnumerator ClickFlash()
    {
        Color originalColor = keyBackground.color;
        keyBackground.color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        keyBackground.color = originalColor;
    }
}
