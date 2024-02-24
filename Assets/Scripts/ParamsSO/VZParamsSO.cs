using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/VillagerAndZombie", fileName = "VZParamsSO", order = 1)]
public class VZParamsSO : ScriptableObject
{
    #region QOL���㏈��
    // ParamsSO���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "VZParamsSO";

    // ParamsSO�̎���
    private static VZParamsSO _entity;
    public static VZParamsSO Entity
    {
        get
        {
            // ���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<VZParamsSO>(PATH);

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

    [Header("���l�𐶂ݏo�����W")] public Vector3[] VillagerSpawnPosList;
    [Header("�]���r�𐶂ݏo�����W")] public Vector3[] ZombieSpawnPosList;
    [Header("�]���r�̑���")] public float ZombieSpeed;
    [Header("���l�̑���")] public float VillagerSpeed;
    [Header("���l�̍ĒT���̊Ԋu(�b)")] public float VillagerRefindPeriod;
    [Header("���l�̍ĒT���̊Ԋu�̌덷(�},�b)")] public float VillagerRefindPeriodOffset;
    [Header("�]���r�̑��l�ɑ΂���ĒT���̊Ԋu(�b)")] public float ZombieRefindVillagerPeriod;
    [Header("�]���r�̑��l�ɑ΂���ĒT���̊Ԋu�̌덷(�},�b)")] public float ZombieRefindVillagerPeriodOffset;
    [Header("���l��������^���x�N�g���́C\ny���ɂ��Ẵ����_���ȉ�]�p�͈̔�\n(���W�A���Ń΂̉��{��:min,max)")] public float[] RandomThetaCoefRange;
    [Header("���l��������^���x�N�g���́C\ny���ɂ��Ẵ����_���ȉ�]�p�͈̔͂���E����m��")] public float RandomThetaOutOfRangeP;
    [Header("�]���r�̃]���r�ɑ΂���ĒT���̊Ԋu(�b)")] public float ZombieRefindZombiePeriod;
    [Header("�]���r�̃]���r�ɑ΂���ĒT���ŁC\n�����Ƃ̋����̏���l")] public float ZombieMaxSelfDistance;
    [Header("�]���r�̃]���r�ɑ΂���ĒT���ŁC\n�Ǘ����Ă���ꍇ�C���̃]���r�Ƃ̋����̍ŏ��l")] public float ZombieOnAloneMinDistance;
    [Header("�]���r�̍ő�̗�")] public int ZombieMaxHP;
    [Header("���l�̍ő�̗�")] public int VillagerMaxHP;
    [Header("�]���r���_���[�W��H�炤���Ƃ̂ł���Ԋu(�b)")] public float ZombieDamagePeriod;
    [Header("���l���_���[�W��H�炤���Ƃ̂ł���Ԋu(�b)")] public float VillagerDamagePeriod;
    [Header("�]���r�̍U����")] public int ZombieAttackPower;
    [Header("���S������s���Ԋu(�b)")] public float KillDecidePeriod;
    [Header("���S����ɂ��鋫�E�̍��W(min,max)(x,y,z)")] public Vector3[] KillLimitPosition;
}
