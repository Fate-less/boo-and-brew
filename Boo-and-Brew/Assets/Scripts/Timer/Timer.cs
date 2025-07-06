using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTMP;
    public float totalDuration = 300f;

    private float elapsedTime = 0f;
    private bool hasEnded = false;

    void Update()
    {
        if (hasEnded) return;

        elapsedTime += Time.deltaTime;

        int hourIndex = Mathf.FloorToInt((elapsedTime / totalDuration) * 6);
        hourIndex = Mathf.Clamp(hourIndex, 0, 5);

        string[] amHours = { "12 AM", "1 AM", "2 AM", "3 AM", "4 AM", "5 AM", "6 AM" };
        timerTMP.text = amHours[hourIndex];

        if (elapsedTime >= totalDuration)
        {
            timerTMP.text = "6 AM";
            hasEnded = true;
            GameEnd();
        }
    }

    private void GameEnd()
    {
        Debug.Log("Game has ended!");
        // Your custom logic here (e.g., trigger win, change scene, etc.)
    }
}
