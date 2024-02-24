using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParamsSO/Other", fileName = "OtherParamsSO", order = 4)]
public class OtherParamsSO : ScriptableObject
{
    #region QOL向上処理
    // ParamsSOが保存してある場所のパス
    public const string PATH = "OtherParamsSO";

    // ParamsSOの実体
    private static OtherParamsSO _entity;
    public static OtherParamsSO Entity
    {
        get
        {
            // 初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<OtherParamsSO>(PATH);

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

    [Header("ゲームのスタート前に，何秒のカウントダウンをするか")] public int CountDownLength;
    [Header("カウントダウン時に，\nタイトルのBGMのボリュームを何倍にするか")] public float OnCountDownTitleBGMVolumeRatio;
    [Header("ゲーム中のBGMのボリューム")] public float GameBGMVolume;
    [Header("プレイヤーのスピード")] public float PlayerSpeed;
    [Header("ゲームが終了してからフェードアウトが始まるまでの時間(秒)")] public float FadeOutWaitTime;
    [Header("フェードアウトが始まってからタイトルに戻るまでの時間(秒)")] public float ToTitleWaitTime;
}