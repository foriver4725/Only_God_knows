using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    [SerializeField] AudioClip skillUse2SE;
    AudioSource audioSource;
    int[] vars;
    bool isVillagerOver = true;
    bool isZombieOver = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 合図が送られ，かつ実行中でないなら
        if (GameManager.Instance.IsSkill2Used)
        {
            GameManager.Instance.IsSkill2Used = false;

            if (!GameManager.Instance.IsSkill2Doing)
            {
                GameManager.Instance.IsSkill2Doing = true;
                isVillagerOver = false;
                isZombieOver = false;

                vars = SkillParamsSO.Entity.Skill2Vars;
                audioSource.PlayOneShot(skillUse2SE);
                StartCoroutine(VillagerHPManager());
                StartCoroutine(ZombieHPManager());
            }
        }
    }

    IEnumerator VillagerHPManager()
    {
        // 全ての村人の体力を5減らし，その後10秒間，毎秒全ての村人の体力を1増やす。
        foreach (GameObject villager in GameManager.Instance.VillagerInstances)
        {
            villager.GetComponent<Villager>().HP -= vars[0];
        }

        for (int i = 0; i < vars[1]; i++)
        {
            yield return new WaitForSeconds(1);

            foreach (GameObject villager in GameManager.Instance.VillagerInstances)
            {
                villager.GetComponent<Villager>().HP += vars[2];
            }
        }

        isVillagerOver = true;
        if (isZombieOver)
        {
            GameManager.Instance.IsSkill2Doing = false;
        }
        yield break;
    }

    IEnumerator ZombieHPManager()
    {
        // 全てのゾンビの体力を10減らし，その後10秒間，毎秒全てのゾンビの体力を1増やす。
        foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
        {
            zombie.GetComponent<Zombie>().HP -= vars[3];
        }

        for (int i = 0; i < vars[4]; i++)
        {
            yield return new WaitForSeconds(1);

            foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
            {
                zombie.GetComponent<Zombie>().HP += vars[5];
            }
        }

        isZombieOver = true;
        if (isVillagerOver)
        {
            GameManager.Instance.IsSkill2Doing = false;
        }
        yield break;
    }
}
