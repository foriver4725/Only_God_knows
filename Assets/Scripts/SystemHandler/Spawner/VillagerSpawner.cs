using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    [SerializeField] GameObject villagerParentPrfb;
    [SerializeField] GameObject villagerPrfb;

    void Start()
    {
        GameObject villagerParent = Instantiate(villagerParentPrfb);

        // �Q�[���J�n���ɑ��l�𐶂ݏo���CVillagerInstances�ɉ�����B
        for (int i = 0; i < VZParamsSO.Entity.VillagerSpawnPosList.Length; i++)
        {
            Vector3 spawnPos = VZParamsSO.Entity.VillagerSpawnPosList[i];
            GameObject newVillager = Instantiate(villagerPrfb, spawnPos, Quaternion.identity, villagerParent.transform);
            GameManager.Instance.VillagerInstances[i] = newVillager;
        }
    }
}
