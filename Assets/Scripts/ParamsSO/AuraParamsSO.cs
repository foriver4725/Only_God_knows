using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/Aura", fileName = "AuraParamsSO", order = 3)]
public class AuraParamsSO : ScriptableObject
{
    #region QOL���㏈��
    // ParamsSO���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "AuraParamsSO";

    // ParamsSO�̎���
    private static AuraParamsSO _entity;
    public static AuraParamsSO Entity
    {
        get
        {
            // ���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<AuraParamsSO>(PATH);

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

    [Header("���d������ꍇ�͔������Ȃ�")]
    [Header("�e�X�g�p�F�ǂ̃I�[���ɂ��邩\n(1~10,100,-100 ; 0�Ȃ炱�̋@�\���I�t�ɂ���)")] public int AuraSelectNumber;
    [Header("�I�[���̏o���Ԋu(�b)")] public float AuraGeneratePeriod;
    [Header("�I�[���̏o���b��")] public float AuraAppearTime;
    [Header("�I�[���̏o������x���W�͈̔�(min,max)")] public Vector2 AuraXRange;
    [Header("�I�[���̏o������z���W�͈̔�(min,max)")] public Vector2 AuraZRange;
    [Header("�I�[���̃��O��\�����鎞��(�b)\n(���I�[���̏o���Ԋu���Z�����邱��)")] public float AuraLogShowTime;
    [Header("�I�[���ɐG�ꂽ���́C�R�X�g�̉񕜗�")] public int AuraCostIncreaseAmount;
    [Header("�I�[��1\n(3�b�ԑS�Ă̑��l�̑�����10���₷)")]
    [Header("������"), Multiline(5)] public string Aura1Detail;
    [Header("�m��(%)")] public int Aura1P;
    [Header("�ϐ�")] public int[] Aura1Vars;
    [Header("�I�[��2\n(�S�Ă̑��l��HP��1���₷)")]
    [Header("������"), Multiline(5)] public string Aura2Detail;
    [Header("�m��(%)")] public int Aura2P;
    [Header("�ϐ�")] public int[] Aura2Vars;
    [Header("�I�[��3\n(3�b�ԑS�Ă̑��l���]���r����_���[�W��H���Ȃ��Ȃ�)")]
    [Header("������"), Multiline(5)] public string Aura3Detail;
    [Header("�m��(%)")] public int Aura3P;
    [Header("�ϐ�")] public int[] Aura3Vars;
    [Header("�I�[��4\n(2�b�ԃ]���r�����l���瓦����悤�ɂȂ�)")]
    [Header("������"), Multiline(5)] public string Aura4Detail;
    [Header("�m��(%)")] public int Aura4P;
    [Header("�ϐ�")] public int[] Aura4Vars;
    [Header("�I�[��5\n(�S�Ẵ]���r��HP��1���炷)")]
    [Header("������"), Multiline(5)] public string Aura5Detail;
    [Header("�m��(%)")] public int Aura5P;
    [Header("�ϐ�")] public int[] Aura5Vars;
    [Header("�I�[��6\n(3�b�ԑS�Ẵ]���r�̓������~�߂�)")]
    [Header("������"), Multiline(5)] public string Aura6Detail;
    [Header("�m��(%)")] public int Aura6P;
    [Header("�ϐ�")] public int[] Aura6Vars;
    [Header("�I�[��7\n(�R�X�g��10�񕜂���)")]
    [Header("������"), Multiline(5)] public string Aura7Detail;
    [Header("�m��(%)")] public int Aura7P;
    [Header("�ϐ�")] public int[] Aura7Vars;
    [Header("�I�[��8\n(�ً}����𔭓�����)")]
    [Header("������"), Multiline(5)] public string Aura8Detail;
    [Header("�m��(%)")] public int Aura8P;
    [Header("�ϐ�")] public int[] Aura8Vars;
    [Header("�I�[��9\n(���l�ƃ]���r�̈ʒu�����ւ���)")]
    [Header("������"), Multiline(5)] public string Aura9Detail;
    [Header("�m��(%)")] public int Aura9P;
    [Header("�ϐ�")] public int[] Aura9Vars;
    [Header("�I�[��10\n(�����N����Ȃ�)")]
    [Header("������"), Multiline(5)] public string Aura10Detail;
    [Header("�m��(%)")] public int Aura10P;
    [Header("�ϐ�")] public int[] Aura10Vars;
    [Header("�I�[�����b�L�[(1%)\n(�T�����q�[�����O�t�@�C�A�𔭓�����)")]
    [Header("������"), Multiline(5)] public string AuraLuckyDetail;
    [Header("�m��(%)")] public int AuraLuckyP;
    [Header("�ϐ�")] public int[] AuraLuckyVars;
    [Header("�I�[���A�����b�L�[(1%)\n(10�b�ԑS�Ă̑��l���]���r�Ɍ������Ă����悤�ɂȂ�)")]
    [Header("������"), Multiline(5)] public string AuraUnLuckyDetail;
    [Header("�m��(%)")] public int AuraUnLuckyP;
    [Header("�ϐ�")] public int[] AuraUnLuckyVars;
}
