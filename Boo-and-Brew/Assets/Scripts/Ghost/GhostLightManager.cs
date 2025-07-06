using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using FunkyCode;

public class GhostLightManager : MonoBehaviour
{
    [Header("Lighting Settings")]
    public LightRoom2D lightRoom;
    public float baseIntensity = 1f;
    public float intensityDecreasePerGhost = 0.1f;
    public float minIntensity = 0.2f;

    [Header("References")]
    public Image spookMeterSlider;

    private static List<Ghost> activeGhosts = new List<Ghost>();
    private static GhostLightManager instance;
    private float originalInterval;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalInterval = SpiritManager.instance.GetSpawnInterval();
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
        if (lightRoom == null) return;

        float targetDesignerIntensity = baseIntensity - (activeGhosts.Count * intensityDecreasePerGhost);
        targetDesignerIntensity = Mathf.Clamp01(Mathf.Max(minIntensity, targetDesignerIntensity));

        float currentDesignerIntensity = Mathf.InverseLerp(63f, 163f, lightRoom.color.a * 255f);
        float smoothIntensity = Mathf.Lerp(currentDesignerIntensity, targetDesignerIntensity, Time.deltaTime * 3f);

        float alpha = Mathf.Lerp(63f, 163f, smoothIntensity) / 255f;

        Color c = lightRoom.color;
        c.a = alpha;
        lightRoom.color = c;

        spookMeterSlider.fillAmount = 1 - smoothIntensity;
        SpiritManager.instance.SetSpawnInterval(originalInterval / smoothIntensity);
    }
}