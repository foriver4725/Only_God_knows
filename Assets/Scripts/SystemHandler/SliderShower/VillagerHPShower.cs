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
        // �����c���Ă��鑺�l�݂̂�HP�����v
        int villagerHPSum = 0;
        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            if (villager.activeSelf)
            {
                villagerHPSum += villager.GetComponent<Villager>().HP;
            }
        }

        // �X���C�_�[�̒l��ύX
        villagerHPSlider.value = villagerHPSum / (float)villagerMaxHPSum; 
    }
}
