using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTextShower : MonoBehaviour
{
    [SerializeField] AudioClip skillSelectSE;
    [SerializeField] TextMeshProUGUI text;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // �{�^���������ꂽ��X�L���𔭓��\��Ԃɂ��C�e�L�X�g��\������B
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // �e�L�X�g���ς�������̂�SE��炷�B
            if (!GameManager.Instance.IsSkill1StandBy)
            {
                audioSource.PlayOneShot(skillSelectSE);
            }

            SkillStandBy(1);
            text.text = SkillParamsSO.Entity.Skill1Detail;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // �e�L�X�g���ς�������̂�SE��炷�B
            if (!GameManager.Instance.IsSkill2StandBy)
            {
                audioSource.PlayOneShot(skillSelectSE);
            }

            SkillStandBy(2);
            text.text = SkillParamsSO.Entity.Skill2Detail;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // �e�L�X�g���ς�������̂�SE��炷�B
            if (!GameManager.Instance.IsSkill3StandBy)
            {
                audioSource.PlayOneShot(skillSelectSE);
            }

            SkillStandBy(3);
            text.text = SkillParamsSO.Entity.Skill3Detail;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // �e�L�X�g���ς�������̂�SE��炷�B
            if (!GameManager.Instance.IsSkill4StandBy)
            {
                audioSource.PlayOneShot(skillSelectSE);
            }

            SkillStandBy(4);
            text.text = SkillParamsSO.Entity.Skill4Detail;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // �e�L�X�g���ς�������̂�SE��炷�B
            if (!GameManager.Instance.IsSkill5StandBy)
            {
                audioSource.PlayOneShot(skillSelectSE);
            }

            SkillStandBy(5);
            text.text = SkillParamsSO.Entity.Skill5Detail;
        }
    }

    // num�̃X�L��1�̂݁Ctrue�ɂ���B
    void SkillStandBy(int num)
    {
        GameManager.Instance.IsSkill1StandBy = num == 1 ? true : false;
        GameManager.Instance.IsSkill2StandBy = num == 2 ? true : false;
        GameManager.Instance.IsSkill3StandBy = num == 3 ? true : false;
        GameManager.Instance.IsSkill4StandBy = num == 4 ? true : false;
        GameManager.Instance.IsSkill5StandBy = num == 5 ? true : false;
    }
}