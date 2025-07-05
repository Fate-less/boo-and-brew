using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class SoultipsManager : MonoBehaviour
{
    public int currentSoultips;
    public TextMeshProUGUI soultipsTMP;

    private void Update()
    {
        currentSoultips += (int) Time.deltaTime;
        soultipsTMP.text = "Soultips: " + currentSoultips.ToString();
    }

    public void ChangeSoultipsValue(int soultips)
    {
        currentSoultips += soultips;
    }
}
