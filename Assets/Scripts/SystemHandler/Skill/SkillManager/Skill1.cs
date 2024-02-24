using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    [SerializeField] AudioClip skillUse1SE;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 合図が送られ，かつ実行中でないなら
        if (GameManager.Instance.IsSkill1Used)
        {
            GameManager.Instance.IsSkill1Used = false;

            if (!GameManager.Instance.IsSkill1Doing)
            {
                GameManager.Instance.IsSkill1Doing = true;

                audioSource.PlayOneShot(skillUse1SE);
                // 角にいる村人を全員中央にワープさせる。
                foreach (GameObject villager in GameManager.Instance.VillagerInstances)
                {
                    if (villager.GetComponent<Villager>().IsAtCorner)
                    {
                        villager.transform.position = new Vector3(0, 0.5f, 0);
                    }
                }

                GameManager.Instance.IsSkill1Doing = false;
            }
        }
    }
}
