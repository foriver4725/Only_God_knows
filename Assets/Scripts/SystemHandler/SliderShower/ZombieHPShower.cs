using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHPShower : MonoBehaviour
{
    [SerializeField] Slider zombieHPSlider;
    int zombieMaxHPSum;

    void Start()
    {
        zombieMaxHPSum = VZParamsSO.Entity.ZombieMaxHP * VZParamsSO.Entity.ZombieSpawnPosList.Length;
    }

    void Update()
    {
        // �����c���Ă���]���r�݂̂�HP�����v
        int zombieHPSum = 0;
        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            if (zombie.activeSelf)
            {
                zombieHPSum += zombie.GetComponent<Zombie>().HP;
            }
        }

        // �X���C�_�[�̒l��ύX
        zombieHPSlider.value = zombieHPSum / (float)zombieMaxHPSum;
    }
}
