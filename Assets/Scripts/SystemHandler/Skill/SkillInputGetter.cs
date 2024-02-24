using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInputGetter : MonoBehaviour
{
    [SerializeField] AudioClip skillDisableSE;
    [SerializeField] Image Skill1Im;
    [SerializeField] Image Skill2Im;
    [SerializeField] Image Skill3Im;
    [SerializeField] Image Skill4Im;
    [SerializeField] Image Skill5Im;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // �X�y�[�X�������ꂽ�Ƃ��C�X�L�������s���łȂ��āC�������\�ŁC���N�[���^�C�����łȂ��āC���R�X�g������Ă���Ȃ�C
        // �X�L���𔭓����鍇�}�𑗂�C�N�[���^�C���̃J�E���g���J�n�B
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameManager.Instance.IsSkill1Doing && GameManager.Instance.IsSkill1StandBy && !GameManager.Instance.IsSkill1OnCoolTime && GameManager.Instance.Cost >= SkillParamsSO.Entity.Skill1Cost)
            {
                GameManager.Instance.IsSkill1OnCoolTime = true;
                GameManager.Instance.Cost -= SkillParamsSO.Entity.Skill1Cost;
                GameManager.Instance.IsSkill1Used = true;
                CoolTimeCount(1);
            }
            else if (!GameManager.Instance.IsSkill2Doing && GameManager.Instance.IsSkill2StandBy && !GameManager.Instance.IsSkill2OnCoolTime && GameManager.Instance.Cost >= SkillParamsSO.Entity.Skill2Cost)
            {
                GameManager.Instance.IsSkill2OnCoolTime = true;
                GameManager.Instance.Cost -= SkillParamsSO.Entity.Skill2Cost;
                GameManager.Instance.IsSkill2Used = true;
                CoolTimeCount(2);
            }
            else if (!GameManager.Instance.IsSkill3Doing && GameManager.Instance.IsSkill3StandBy && !GameManager.Instance.IsSkill3OnCoolTime && GameManager.Instance.Cost >= SkillParamsSO.Entity.Skill3Cost)
            {
                GameManager.Instance.IsSkill3OnCoolTime = true;
                GameManager.Instance.Cost -= SkillParamsSO.Entity.Skill3Cost;
                GameManager.Instance.IsSkill3Used = true;
                CoolTimeCount(3);
            }
            else if (!GameManager.Instance.IsSkill4Doing && GameManager.Instance.IsSkill4StandBy && !GameManager.Instance.IsSkill4OnCoolTime && GameManager.Instance.Cost >= SkillParamsSO.Entity.Skill4Cost)
            {
                GameManager.Instance.IsSkill4OnCoolTime = true;
                GameManager.Instance.Cost -= SkillParamsSO.Entity.Skill4Cost;
                GameManager.Instance.IsSkill4Used = true;
                CoolTimeCount(4);
            }
            else if (!GameManager.Instance.IsSkill5Doing && GameManager.Instance.IsSkill5StandBy && !GameManager.Instance.IsSkill5OnCoolTime && GameManager.Instance.Cost >= SkillParamsSO.Entity.Skill5Cost)
            {
                GameManager.Instance.IsSkill5OnCoolTime = true;
                GameManager.Instance.Cost -= SkillParamsSO.Entity.Skill5Cost;
                GameManager.Instance.IsSkill5Used = true;
                CoolTimeCount(5);
            }
            else
            {
                // �X�L�����g���Ȃ�SE��炷�B
                audioSource.PlayOneShot(skillDisableSE);
            }
        }
    }

    void CoolTimeCount(int num)
    {
        float coolTime = 0;

        // �N�[���^�C�����擾
        if (num == 1) { coolTime = SkillParamsSO.Entity.Skill1CoolTime; }
        else if (num == 2) { coolTime = SkillParamsSO.Entity.Skill2CoolTime; }
        else if (num == 3) { coolTime = SkillParamsSO.Entity.Skill3CoolTime; }
        else if (num == 4) { coolTime = SkillParamsSO.Entity.Skill4CoolTime; }
        else if (num == 5) { coolTime = SkillParamsSO.Entity.Skill5CoolTime; }

        StartCoroutine(CoolTimeManager(num, coolTime));
    }

    // �N�[���^�C���̃J�E���g
    IEnumerator CoolTimeManager(int num, float ct)
    {
        float time = 0;

        while (true)
        {
            // �J�E���g
            yield return new WaitForSeconds(SkillParamsSO.Entity.CoolTimeCountPeriod);
            time += SkillParamsSO.Entity.CoolTimeCountPeriod;

            // FillAmount��ύX
            if (num == 1) { Skill1Im.fillAmount = time / ct; }
            else if (num == 2) { Skill2Im.fillAmount = time / ct; }
            else if (num == 3) { Skill3Im.fillAmount = time / ct; }
            else if (num == 4) { Skill4Im.fillAmount = time / ct; }
            else if (num == 5) { Skill5Im.fillAmount = time / ct; }

            // �J�E���g���I��鎞�ԂɂȂ���
            if (time >= ct)
            {
                break;
            }
        }

        // �N�[���^�C�����łȂ�����B
        if (num == 1) { GameManager.Instance.IsSkill1OnCoolTime = false; }
        else if (num == 2) { GameManager.Instance.IsSkill2OnCoolTime = false; }
        else if (num == 3) { GameManager.Instance.IsSkill3OnCoolTime = false; }
        else if (num == 4) { GameManager.Instance.IsSkill4OnCoolTime = false; }
        else if (num == 5) { GameManager.Instance.IsSkill5OnCoolTime = false; }

        yield break;
    }
}