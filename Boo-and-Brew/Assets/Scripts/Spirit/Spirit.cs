using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spirit", menuName = "Spirits/Spirit")]
public class Spirit : ScriptableObject
{
    public string spiritName;
    public GameObject prefab;
    // Bisa di ekspan jdi ada favorite tea nya or something
}
