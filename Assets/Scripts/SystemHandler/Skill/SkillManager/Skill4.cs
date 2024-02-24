using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    [SerializeField] AudioClip skillUse4SE;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 合図が送られ，かつ実行中でないなら
        if (GameManager.Instance.IsSkill4Used)
        {
            GameManager.Instance.IsSkill4Used = false;

            if (!GameManager.Instance.IsSkill4Doing)
            {
                GameManager.Instance.IsSkill4Doing = true;

                audioSource.PlayOneShot(skillUse4SE);
                // 集団から孤立したゾンビを全て倒す。
                foreach (GameObject zombie in GameManager.Instance.ZombieInstances)
                {
                    Zombie zombieClass = zombie.GetComponent<Zombie>();
                    if (zombieClass.IsAlone)
                    {
                        zombieClass.HP = 0;
                    }
                }

                GameManager.Instance.IsSkill4Doing = false;
            }
        }
    }
}
