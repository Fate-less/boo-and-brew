using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class SoultipsManager : MonoBehaviour
{
    public static SoultipsManager instance;
    public int currentSoultips;
    public TextMeshProUGUI soultipsTMP;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        soultipsTMP.text = "x" + currentSoultips.ToString();
    }

    public void ChangeSoultipsValue(int soultips)
    {
        currentSoultips += soultips;
    }
}
