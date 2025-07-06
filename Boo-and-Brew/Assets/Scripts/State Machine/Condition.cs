using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    protected virtual void Start() { }
    protected virtual void Update() { }

    public abstract bool ConditionCheck();
}