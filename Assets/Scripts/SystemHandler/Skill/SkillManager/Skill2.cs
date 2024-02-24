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
        // ���}�������C�����s���łȂ��Ȃ�
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
        // �S�Ă̑��l�̗̑͂�5���炵�C���̌�10�b�ԁC���b�S�Ă̑��l�̗̑͂�1���₷�B
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
        // �S�Ẵ]���r�̗̑͂�10���炵�C���̌�10�b�ԁC���b�S�Ẵ]���r�̗̑͂�1���₷�B
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
