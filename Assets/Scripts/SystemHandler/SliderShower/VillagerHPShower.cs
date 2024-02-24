using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagerHPShower : MonoBehaviour
{
    [SerializeField] Slider villagerHPSlider;
    int villagerMaxHPSum;
 
    void Start()
    {
        villagerMaxHPSum = VZParamsSO.Entity.VillagerMaxHP * VZParamsSO.Entity.VillagerSpawnPosList.Length;
    }

    void Update()
    {
        // 生き残っている村人のみのHPを合計
        int villagerHPSum = 0;
        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            if (villager.activeSelf)
            {
                villagerHPSum += villager.GetComponent<Villager>().HP;
            }
        }

        // スライダーの値を変更
        villagerHPSlider.value = villagerHPSum / (float)villagerMaxHPSum; 
    }
}
