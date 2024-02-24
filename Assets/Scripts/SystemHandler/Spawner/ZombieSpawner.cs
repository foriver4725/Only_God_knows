using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombieParentPrfb;
    [SerializeField] GameObject zombiePrfb;

    void Start()
    {
        GameObject zombieParent = Instantiate(zombieParentPrfb);

        // ゲーム開始時にゾンビを生み出し，ZombieInstancesに加える。
        for (int i = 0; i < VZParamsSO.Entity.ZombieSpawnPosList.Length; i++)
        {
            Vector3 spawnPos = VZParamsSO.Entity.ZombieSpawnPosList[i];
            GameObject newZombie = Instantiate(zombiePrfb, spawnPos, Quaternion.identity, zombieParent.transform);
            GameManager.Instance.ZombieInstances[i] = newZombie;
        }
    }
}
