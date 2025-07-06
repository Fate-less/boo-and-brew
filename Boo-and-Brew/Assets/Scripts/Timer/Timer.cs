using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Duration")]
    public float totalDuration = 300f;
    [Header("References")]
    public TextMeshProUGUI timerTMP;
    public PlayerBrewer playerBrewer;
    public TextMeshProUGUI spiritServedTMP;
    public TextMeshProUGUI personalBestTMP;
    public GameObject endGameObject;

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
        int personalBest = PlayerPrefs.GetInt("personalBest", 0);
        if(playerBrewer.servedSpirit > personalBest)
        {
            PlayerPrefs.SetInt("personalBest", playerBrewer.servedSpirit);
            personalBest = playerBrewer.servedSpirit;
        }
        spiritServedTMP.text = "Spirit served: " + playerBrewer.servedSpirit.ToString();
        personalBestTMP.text = "Personal best: " + personalBest.ToString();
        endGameObject.SetActive(true);
    }
}
