using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/VillagerAndZombie", fileName = "VZParamsSO", order = 1)]
public class VZParamsSO : ScriptableObject
{
    #region QOL向上処理
    // ParamsSOが保存してある場所のパス
    public const string PATH = "VZParamsSO";

    // ParamsSOの実体
    private static VZParamsSO _entity;
    public static VZParamsSO Entity
    {
        get
        {
            // 初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<VZParamsSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
    #endregion

    [Header("村人を生み出す座標")] public Vector3[] VillagerSpawnPosList;
    [Header("ゾンビを生み出す座標")] public Vector3[] ZombieSpawnPosList;
    [Header("ゾンビの速さ")] public float ZombieSpeed;
    [Header("村人の速さ")] public float VillagerSpeed;
    [Header("村人の再探査の間隔(秒)")] public float VillagerRefindPeriod;
    [Header("村人の再探査の間隔の誤差(±,秒)")] public float VillagerRefindPeriodOffset;
    [Header("ゾンビの村人に対する再探査の間隔(秒)")] public float ZombieRefindVillagerPeriod;
    [Header("ゾンビの村人に対する再探査の間隔の誤差(±,秒)")] public float ZombieRefindVillagerPeriodOffset;
    [Header("村人が逃げる運動ベクトルの，\ny軸についてのランダムな回転角の範囲\n(ラジアンでπの何倍か:min,max)")] public float[] RandomThetaCoefRange;
    [Header("村人が逃げる運動ベクトルの，\ny軸についてのランダムな回転角の範囲を逸脱する確率")] public float RandomThetaOutOfRangeP;
    [Header("ゾンビのゾンビに対する再探査の間隔(秒)")] public float ZombieRefindZombiePeriod;
    [Header("ゾンビのゾンビに対する再探査で，\n自分との距離の上限値")] public float ZombieMaxSelfDistance;
    [Header("ゾンビのゾンビに対する再探査で，\n孤立している場合，他のゾンビとの距離の最小値")] public float ZombieOnAloneMinDistance;
    [Header("ゾンビの最大体力")] public int ZombieMaxHP;
    [Header("村人の最大体力")] public int VillagerMaxHP;
    [Header("ゾンビがダメージを食らうことのできる間隔(秒)")] public float ZombieDamagePeriod;
    [Header("村人がダメージを食らうことのできる間隔(秒)")] public float VillagerDamagePeriod;
    [Header("ゾンビの攻撃力")] public int ZombieAttackPower;
    [Header("死亡判定を行う間隔(秒)")] public float KillDecidePeriod;
    [Header("死亡判定にする境界の座標(min,max)(x,y,z)")] public Vector3[] KillLimitPosition;
}
