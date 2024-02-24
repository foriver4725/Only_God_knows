using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/Aura", fileName = "AuraParamsSO", order = 3)]
public class AuraParamsSO : ScriptableObject
{
    #region QOL向上処理
    // ParamsSOが保存してある場所のパス
    public const string PATH = "AuraParamsSO";

    // ParamsSOの実体
    private static AuraParamsSO _entity;
    public static AuraParamsSO Entity
    {
        get
        {
            // 初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<AuraParamsSO>(PATH);

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

    [Header("※重複する場合は発動しない")]
    [Header("テスト用：どのオーラにするか\n(1~10,100,-100 ; 0ならこの機能をオフにする)")] public int AuraSelectNumber;
    [Header("オーラの出現間隔(秒)")] public float AuraGeneratePeriod;
    [Header("オーラの出現秒数")] public float AuraAppearTime;
    [Header("オーラの出現するx座標の範囲(min,max)")] public Vector2 AuraXRange;
    [Header("オーラの出現するz座標の範囲(min,max)")] public Vector2 AuraZRange;
    [Header("オーラのログを表示する時間(秒)\n(※オーラの出現間隔より短くすること)")] public float AuraLogShowTime;
    [Header("オーラに触れた時の，コストの回復量")] public int AuraCostIncreaseAmount;
    [Header("オーラ1\n(3秒間全ての村人の速さを10増やす)")]
    [Header("説明文"), Multiline(5)] public string Aura1Detail;
    [Header("確率(%)")] public int Aura1P;
    [Header("変数")] public int[] Aura1Vars;
    [Header("オーラ2\n(全ての村人のHPを1増やす)")]
    [Header("説明文"), Multiline(5)] public string Aura2Detail;
    [Header("確率(%)")] public int Aura2P;
    [Header("変数")] public int[] Aura2Vars;
    [Header("オーラ3\n(3秒間全ての村人がゾンビからダメージを食らわなくなる)")]
    [Header("説明文"), Multiline(5)] public string Aura3Detail;
    [Header("確率(%)")] public int Aura3P;
    [Header("変数")] public int[] Aura3Vars;
    [Header("オーラ4\n(2秒間ゾンビが村人から逃げるようになる)")]
    [Header("説明文"), Multiline(5)] public string Aura4Detail;
    [Header("確率(%)")] public int Aura4P;
    [Header("変数")] public int[] Aura4Vars;
    [Header("オーラ5\n(全てのゾンビのHPを1減らす)")]
    [Header("説明文"), Multiline(5)] public string Aura5Detail;
    [Header("確率(%)")] public int Aura5P;
    [Header("変数")] public int[] Aura5Vars;
    [Header("オーラ6\n(3秒間全てのゾンビの動きを止める)")]
    [Header("説明文"), Multiline(5)] public string Aura6Detail;
    [Header("確率(%)")] public int Aura6P;
    [Header("変数")] public int[] Aura6Vars;
    [Header("オーラ7\n(コストを10回復する)")]
    [Header("説明文"), Multiline(5)] public string Aura7Detail;
    [Header("確率(%)")] public int Aura7P;
    [Header("変数")] public int[] Aura7Vars;
    [Header("オーラ8\n(緊急回避を発動する)")]
    [Header("説明文"), Multiline(5)] public string Aura8Detail;
    [Header("確率(%)")] public int Aura8P;
    [Header("変数")] public int[] Aura8Vars;
    [Header("オーラ9\n(村人とゾンビの位置を入れ替える)")]
    [Header("説明文"), Multiline(5)] public string Aura9Detail;
    [Header("確率(%)")] public int Aura9P;
    [Header("変数")] public int[] Aura9Vars;
    [Header("オーラ10\n(何も起こらない)")]
    [Header("説明文"), Multiline(5)] public string Aura10Detail;
    [Header("確率(%)")] public int Aura10P;
    [Header("変数")] public int[] Aura10Vars;
    [Header("オーララッキー(1%)\n(サモンヒーリングファイアを発動する)")]
    [Header("説明文"), Multiline(5)] public string AuraLuckyDetail;
    [Header("確率(%)")] public int AuraLuckyP;
    [Header("変数")] public int[] AuraLuckyVars;
    [Header("オーラアンラッキー(1%)\n(10秒間全ての村人がゾンビに向かっていくようになる)")]
    [Header("説明文"), Multiline(5)] public string AuraUnLuckyDetail;
    [Header("確率(%)")] public int AuraUnLuckyP;
    [Header("変数")] public int[] AuraUnLuckyVars;
}
