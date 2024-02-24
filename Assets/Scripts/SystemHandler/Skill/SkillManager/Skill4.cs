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
        // ���}�������C�����s���łȂ��Ȃ�
        if (GameManager.Instance.IsSkill4Used)
        {
            GameManager.Instance.IsSkill4Used = false;

            if (!GameManager.Instance.IsSkill4Doing)
            {
                GameManager.Instance.IsSkill4Doing = true;

                audioSource.PlayOneShot(skillUse4SE);
                // �W�c����Ǘ������]���r��S�ē|���B
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
