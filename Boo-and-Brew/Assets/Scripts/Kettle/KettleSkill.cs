using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KettleSkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private KettleManager kettleManager;
    [SerializeField] private TMP_Text kettlePriceTMP;
    [SerializeField] private Image kettleImage;

    [Header("Stats")]
    [SerializeField] private int kettlePrice;

    private SoultipsManager soultipsManager;

    private void Start()
    {
        soultipsManager = SoultipsManager.instance.GetComponent<SoultipsManager>();
    }

    private void Update()
    {
        if(soultipsManager.currentSoultips > kettlePrice)
            kettleImage.color = new Color(kettleImage.color.r, kettleImage.color.g, kettleImage.color.b, 100f);
        else
            kettleImage.color = new Color(kettleImage.color.r, kettleImage.color.g, kettleImage.color.b, 255f);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BuyKettle();
        }
    }

    public void BuyKettle()
    {
        if(soultipsManager.currentSoultips < kettlePrice)
        {
            return;
        }
        kettleManager.SpawnKettle();
        soultipsManager.ChangeSoultipsValue(kettlePrice * -1);
    }
}
