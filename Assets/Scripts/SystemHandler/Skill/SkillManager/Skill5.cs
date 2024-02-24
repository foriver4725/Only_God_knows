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
        // ���}�������C�����s���łȂ��Ȃ�
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

        // �q�[�����O�t�@�C�A�͏�ɂ��鑺�l�̗̑͂���ɍő�ɕۂ�(�C1�b�����ɏ�ɂ���]���r�̗̑͂�1���炷)�B
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
        // �t�B�[���h�S���10�b�ԃq�[�����O�t�@�C�A��W�J����B
        isHealingFireSet = true;
        ground.GetComponent<Renderer>().material.color = Color.red;

        for (int i = 0; i < vars[0]; i++)
        {
            // �q�[�����O�t�@�C�A��(��ɂ��鑺�l�̗̑͂���ɍő�ɕۂ�)�C1�b�����ɏ�ɂ���]���r�̗̑͂�1���炷�B
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
