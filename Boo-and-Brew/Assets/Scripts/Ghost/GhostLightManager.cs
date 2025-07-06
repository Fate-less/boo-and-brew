using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class GhostLightManager : MonoBehaviour
{
    [Header("Lighting Settings")]
    public Light2D globalLight;
    public float baseIntensity = 1f;
    public float intensityDecreasePerGhost = 0.1f;
    public float minIntensity = 0.2f;

    [Header("References")]
    public Image spookMeterSlider;

    private static List<Ghost> activeGhosts = new List<Ghost>();
    private static GhostLightManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateLightIntensity();
    }

    public static void RegisterGhost(Ghost ghost)
    {
        if (!activeGhosts.Contains(ghost))
        {
            activeGhosts.Add(ghost);
        }
    }

    public static void UnregisterGhost(Ghost ghost)
    {
        if (activeGhosts.Contains(ghost))
        {
            activeGhosts.Remove(ghost);
        }
    }

    private void UpdateLightIntensity()
    {
        if (globalLight == null) return;

        float targetIntensity = baseIntensity - (activeGhosts.Count * intensityDecreasePerGhost);
        float smoothIntensity = Mathf.Lerp(globalLight.intensity, Mathf.Max(minIntensity, targetIntensity), Time.deltaTime * 3f);
        globalLight.intensity = smoothIntensity;
        spookMeterSlider.fillAmount = 1 - smoothIntensity;
        SpiritManager.instance.SetSpawnInterval(5 / smoothIntensity);
    }
}