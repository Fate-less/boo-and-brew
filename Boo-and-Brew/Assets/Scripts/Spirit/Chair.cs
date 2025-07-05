using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public bool IsOccupied { get; private set; }

    public void Occupy()
    {
        IsOccupied = true;
    }

    public void Vacate()
    {
        IsOccupied = false;
    }
}