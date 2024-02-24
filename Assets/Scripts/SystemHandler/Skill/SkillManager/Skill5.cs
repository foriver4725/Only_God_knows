using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] AudioClip skillUse5SE;
    AudioSource audioSource;
    int[] vars;
    bool isHealingFireSet = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 合図が送られ，かつ実行中でないなら
        if (GameManager.Instance.IsSkill5Used)
        {
            GameManager.Instance.IsSkill5Used = false;

            if (!GameManager.Instance.IsSkill5Doing)
            {
                GameManager.Instance.IsSkill5Doing = true;

                vars = SkillParamsSO.Entity.Skill5Vars;
                audioSource.PlayOneShot(skillUse5SE);
                StartCoroutine(SetFire());
            }
        }

        // ヒーリングファイアは上にいる村人の体力を常に最大に保ち(，1秒おきに上にいるゾンビの体力を1減らす)。
        if (isHealingFireSet)
        {
            foreach (GameObject villager in GameManager.Instance.VillagerInstances)
            {
                if (Mathf.Abs(villager.transform.position.y - 0.5f) <= 0.01f)
                {
                    villager.GetComponent<Villager>().HP = VZParamsSO.Entity.VillagerMaxHP;
                }
            }
        }
    }

    IEnumerator SetFire()
    {
        // フィールド全域に10秒間ヒーリングファイアを展開する。
        isHealingFireSet = true;
        ground.GetComponent<Renderer>().material.color = Color.red;

        for (int i = 0; i < vars[0]; i++)
        {
            // ヒーリングファイアは(上にいる村人の体力を常に最大に保ち)，1秒おきに上にいるゾンビの体力を1減らす。
            yield return new WaitForSeconds(vars[1]);

            foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
            {
                if (Mathf.Abs(zombie.transform.position.y - 0.5f) <= 0.01f)
                {
                    zombie.GetComponent<Zombie>().HP -= vars[2];
                } 
            }
        }

        isHealingFireSet = false;
        ground.GetComponent<Renderer>().material.color = Color.black;
        GameManager.Instance.IsSkill5Doing = false;
        yield break;
    }
}
