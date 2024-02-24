using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/Skill", fileName = "SkillParamsSO", order = 2)]
public class SkillParamsSO : ScriptableObject
{
    #region QOL向上処理
    // ParamsSOが保存してある場所のパス
    public const string PATH = "SkillParamsSO";

    // ParamsSOの実体
    private static SkillParamsSO _entity;
    public static SkillParamsSO Entity
    {
        get
        {
            // 初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<SkillParamsSO>(PATH);

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

    [Header("※重複する場合は発動しない\n※プレイヤーは，実行中のスキルに\n    同じスキルを重ねて発動できない")]
    [Header("コストの最大値")] public int CostMaxAmount;
    [Header("コストを回復する間隔(秒)")] public float CostIncreasePeriod;
    [Header("コストの1回の回復量")] public int CostIncreaseWeight;
    [Header("クールタイムのカウントの処理を何秒ごとに行うか")] public float CoolTimeCountPeriod;
    [Header("スキル1\n(緊急回避)")]
    [Header("色")] public Color Skill1Color;
    [Header("コスト")] public int Skill1Cost;
    [Header("クールタイム")] public float Skill1CoolTime;
    [Header("説明文"), Multiline(5)] public string Skill1Detail;
    [Header("変数")] public int[] Skill1Vars;
    [Header("スキル2\n(いたずら好きな妖精)")]
    [Header("色")] public Color Skill2Color;
    [Header("コスト")] public int Skill2Cost;
    [Header("クールタイム")] public float Skill2CoolTime;
    [Header("説明文"), Multiline(5)] public string Skill2Detail;
    [Header("変数")] public int[] Skill2Vars;
    [Header("スキル3\n(強力な助っ人)")]
    [Header("色")] public Color Skill3Color;
    [Header("コスト")] public int Skill3Cost;
    [Header("クールタイム")] public float Skill3CoolTime;
    [Header("説明文"), Multiline(5)] public string Skill3Detail;
    [Header("変数")] public int[] Skill3Vars;
    [Header("スキル4\n(狩りの心得)")]
    [Header("色")] public Color Skill4Color;
    [Header("コスト")] public int Skill4Cost;
    [Header("クールタイム")] public float Skill4CoolTime;
    [Header("説明文"), Multiline(5)] public string Skill4Detail;
    [Header("変数")] public int[] Skill4Vars;
    [Header("スキル5\n(サモンヒーリングファイア)")]
    [Header("色")] public Color Skill5Color;
    [Header("コスト")] public int Skill5Cost;
    [Header("クールタイム")] public float Skill5CoolTime;
    [Header("説明文"), Multiline(5)] public string Skill5Detail;
    [Header("変数")] public int[] Skill5Vars;
}
