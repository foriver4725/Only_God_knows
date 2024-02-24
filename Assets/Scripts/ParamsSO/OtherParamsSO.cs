using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/Other", fileName = "OtherParamsSO", order = 4)]
public class OtherParamsSO : ScriptableObject
{
    #region QOL���㏈��
    // ParamsSO���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "OtherParamsSO";

    // ParamsSO�̎���
    private static OtherParamsSO _entity;
    public static OtherParamsSO Entity
    {
        get
        {
            // ���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<OtherParamsSO>(PATH);

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

    [Header("�Q�[���̃X�^�[�g�O�ɁC���b�̃J�E���g�_�E�������邩")] public int CountDownLength;
    [Header("�J�E���g�_�E�����ɁC\n�^�C�g����BGM�̃{�����[�������{�ɂ��邩")] public float OnCountDownTitleBGMVolumeRatio;
    [Header("�Q�[������BGM�̃{�����[��")] public float GameBGMVolume;
    [Header("�v���C���[�̃X�s�[�h")] public float PlayerSpeed;
    [Header("�Q�[�����I�����Ă���t�F�[�h�A�E�g���n�܂�܂ł̎���(�b)")] public float FadeOutWaitTime;
    [Header("�t�F�[�h�A�E�g���n�܂��Ă���^�C�g���ɖ߂�܂ł̎���(�b)")] public float ToTitleWaitTime;
}