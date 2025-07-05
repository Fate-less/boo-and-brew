using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrewer : Player
{
    [SerializeField] private Transform handPosition;

    private GameObject carriedTea;

    public bool IsCarryingTea() => carriedTea != null;

    public void PickUpTea(GameObject tea)
    {
        if (carriedTea != null) return;

        carriedTea = tea;
        tea.transform.SetParent(handPosition);
        tea.transform.localPosition = Vector3.zero;
        tea.transform.localRotation = Quaternion.identity;
    }

    /* Belom dipake sekarang, menu teh msih satu
    public void DropTea()
    {
        if (carriedTea == null) return;

        carriedTea.transform.SetParent(null);
        carriedTea = null;
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ghost") && IsCarryingTea())
        {
            Destroy(carriedTea);
            Destroy(collision.gameObject);
            carriedTea = null;
            //berhasil serving teh
        }
    }

    public GameObject GetTea() => carriedTea;
}

