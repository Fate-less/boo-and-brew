using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Header("Referencing")]
    public List<Condition> conditionList;
    public List<State> stateList;

    private void Update()
    {
        for (int i = 0; i < conditionList.Count; i++)
        {
            stateList[i].enabled = conditionList[i].ConditionCheck();
        }
    }
}