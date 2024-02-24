using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SkillCostIncreaser : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CostIncrease());
    }

    // 一定周期でコストを増やす
    IEnumerator CostIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(SkillParamsSO.Entity.CostIncreasePeriod);
            GameManager.Instance.Cost += SkillParamsSO.Entity.CostIncreaseWeight;
            // 最大値以上には増えない
            if (GameManager.Instance.Cost >= SkillParamsSO.Entity.CostMaxAmount)
            {
                GameManager.Instance.Cost = SkillParamsSO.Entity.CostMaxAmount;
            }
        }
    }
}
