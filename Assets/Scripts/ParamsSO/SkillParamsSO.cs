using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/Skill", fileName = "SkillParamsSO", order = 2)]
public class SkillParamsSO : ScriptableObject
{
    #region QOL���㏈��
    // ParamsSO���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "SkillParamsSO";

    // ParamsSO�̎���
    private static SkillParamsSO _entity;
    public static SkillParamsSO Entity
    {
        get
        {
            // ���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<SkillParamsSO>(PATH);

                //���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
    #endregion

    [Header("���d������ꍇ�͔������Ȃ�\n���v���C���[�́C���s���̃X�L����\n    �����X�L�����d�˂Ĕ����ł��Ȃ�")]
    [Header("�R�X�g�̍ő�l")] public int CostMaxAmount;
    [Header("�R�X�g���񕜂���Ԋu(�b)")] public float CostIncreasePeriod;
    [Header("�R�X�g��1��̉񕜗�")] public int CostIncreaseWeight;
    [Header("�N�[���^�C���̃J�E���g�̏��������b���Ƃɍs����")] public float CoolTimeCountPeriod;
    [Header("�X�L��1\n(�ً}���)")]
    [Header("�F")] public Color Skill1Color;
    [Header("�R�X�g")] public int Skill1Cost;
    [Header("�N�[���^�C��")] public float Skill1CoolTime;
    [Header("������"), Multiline(5)] public string Skill1Detail;
    [Header("�ϐ�")] public int[] Skill1Vars;
    [Header("�X�L��2\n(��������D���ȗd��)")]
    [Header("�F")] public Color Skill2Color;
    [Header("�R�X�g")] public int Skill2Cost;
    [Header("�N�[���^�C��")] public float Skill2CoolTime;
    [Header("������"), Multiline(5)] public string Skill2Detail;
    [Header("�ϐ�")] public int[] Skill2Vars;
    [Header("�X�L��3\n(���͂ȏ����l)")]
    [Header("�F")] public Color Skill3Color;
    [Header("�R�X�g")] public int Skill3Cost;
    [Header("�N�[���^�C��")] public float Skill3CoolTime;
    [Header("������"), Multiline(5)] public string Skill3Detail;
    [Header("�ϐ�")] public int[] Skill3Vars;
    [Header("�X�L��4\n(���̐S��)")]
    [Header("�F")] public Color Skill4Color;
    [Header("�R�X�g")] public int Skill4Cost;
    [Header("�N�[���^�C��")] public float Skill4CoolTime;
    [Header("������"), Multiline(5)] public string Skill4Detail;
    [Header("�ϐ�")] public int[] Skill4Vars;
    [Header("�X�L��5\n(�T�����q�[�����O�t�@�C�A)")]
    [Header("�F")] public Color Skill5Color;
    [Header("�R�X�g")] public int Skill5Cost;
    [Header("�N�[���^�C��")] public float Skill5CoolTime;
    [Header("������"), Multiline(5)] public string Skill5Detail;
    [Header("�ϐ�")] public int[] Skill5Vars;
}
