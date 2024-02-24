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

    // �������ŃR�X�g�𑝂₷
    IEnumerator CostIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(SkillParamsSO.Entity.CostIncreasePeriod);
            GameManager.Instance.Cost += SkillParamsSO.Entity.CostIncreaseWeight;
            // �ő�l�ȏ�ɂ͑����Ȃ�
            if (GameManager.Instance.Cost >= SkillParamsSO.Entity.CostMaxAmount)
            {
                GameManager.Instance.Cost = SkillParamsSO.Entity.CostMaxAmount;
            }
        }
    }
}
