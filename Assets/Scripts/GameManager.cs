using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region staticかつシングルトンにする
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] AudioSource gameBGMAs;
    [SerializeField] AudioSource clearSEAs;
    [SerializeField] AudioSource gameOverSEAs;
    [SerializeField] AudioClip[] gameBGMList;
    [SerializeField] AudioClip clearSE;
    [SerializeField] AudioClip gameOverSE;
    [SerializeField] TextMeshProUGUI logText;
    [SerializeField] Image fadeOutIm;
    [Space(50)]
    [System.NonSerialized] public GameObject[] VillagerInstances; // 村人のインスタンス格納
    [System.NonSerialized] public GameObject[] ZombieInstances; // ゾンビのインスタンス格納
    [System.NonSerialized] public int VillagerNumber; // 村人の数
    [System.NonSerialized] public int ZombieNumber; // ゾンビの数
    [System.NonSerialized] public int Cost; // コスト
    [System.NonSerialized] public bool IsGetAura = false; // オーラを取得したかどうか
    [System.NonSerialized] public bool IsToDestroyAura = false; // オーラを消す必要があるかどうか
    [System.NonSerialized] public bool IsClear = false; // クリアかどうか
    [System.NonSerialized] public bool IsGameOver = false; // ゲームオーバーかどうか
    #region スキルが発動可能かどうか
    [System.NonSerialized] public bool IsSkill1StandBy = false;
    [System.NonSerialized] public bool IsSkill2StandBy = false;
    [System.NonSerialized] public bool IsSkill3StandBy = false;
    [System.NonSerialized] public bool IsSkill4StandBy = false;
    [System.NonSerialized] public bool IsSkill5StandBy = false;
    #endregion
    #region スキルが発動されたかどうか(合図として使う)
    [System.NonSerialized] public bool IsSkill1Used = false;
    [System.NonSerialized] public bool IsSkill2Used = false;
    [System.NonSerialized] public bool IsSkill3Used = false;
    [System.NonSerialized] public bool IsSkill4Used = false;
    [System.NonSerialized] public bool IsSkill5Used = false;
    #endregion
    #region スキルが発動中かどうか
    [System.NonSerialized] public bool IsSkill1Doing = false;
    [System.NonSerialized] public bool IsSkill2Doing = false;
    [System.NonSerialized] public bool IsSkill3Doing = false;
    [System.NonSerialized] public bool IsSkill4Doing = false;
    [System.NonSerialized] public bool IsSkill5Doing = false;
    #endregion
    #region スキルがクールタイム中かどうか
    [System.NonSerialized] public bool IsSkill1OnCoolTime = false;
    [System.NonSerialized] public bool IsSkill2OnCoolTime = false;
    [System.NonSerialized] public bool IsSkill3OnCoolTime = false;
    [System.NonSerialized] public bool IsSkill4OnCoolTime = false;
    [System.NonSerialized] public bool IsSkill5OnCoolTime = false;
    #endregion
    #region オーラが発動中かどうか
    [System.NonSerialized] public bool IsAura1Doing = false;
    [System.NonSerialized] public bool IsAura2Doing = false;
    [System.NonSerialized] public bool IsAura3Doing = false;
    [System.NonSerialized] public bool IsAura4Doing = false;
    [System.NonSerialized] public bool IsAura5Doing = false;
    [System.NonSerialized] public bool IsAura6Doing = false;
    [System.NonSerialized] public bool IsAura7Doing = false;
    [System.NonSerialized] public bool IsAura8Doing = false;
    [System.NonSerialized] public bool IsAura9Doing = false;
    [System.NonSerialized] public bool IsAura10Doing = false;
    [System.NonSerialized] public bool IsAuraLuckyDoing = false;
    [System.NonSerialized] public bool IsAuraUnLuckyDoing = false;
    #endregion
    bool isFadeOutStarted = false; // フェードアウトが始まったかどうか

    void Start()
    {
        // 生成する前に，格納用の配列を作る。
        VillagerInstances = new GameObject[VZParamsSO.Entity.VillagerSpawnPosList.Length];
        ZombieInstances = new GameObject[VZParamsSO.Entity.ZombieSpawnPosList.Length];

        VillagerNumber = VZParamsSO.Entity.VillagerSpawnPosList.Length;
        ZombieNumber = VZParamsSO.Entity.ZombieSpawnPosList.Length;

        // BGMを再生
        gameBGMAs.clip = gameBGMList[Random.Range(0, gameBGMList.Length)];
        gameBGMAs.volume = OtherParamsSO.Entity.GameBGMVolume;
        gameBGMAs.Play();
    }

    void Update()
    {
        // クリア，ゲームオーバーの判定
        if (ZombieNumber <= 0 && !IsGameOver)
        {
            IsClear = true;
            logText.text = "<size=90><color=#FFFF00>撃退</color></size>";

            if (!isFadeOutStarted)
            {
                isFadeOutStarted = true;
                clearSEAs.PlayOneShot(clearSE);
                StartCoroutine(FadeOut());
            }
        }
        else if (VillagerNumber <= 0 && !IsClear)
        {
            IsGameOver = true;
            logText.text = "<size=90><color=#FF0000>全滅</color></size>";

            if (!isFadeOutStarted)
            {
                isFadeOutStarted = true;
                gameOverSEAs.PlayOneShot(gameOverSE);
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(OtherParamsSO.Entity.FadeOutWaitTime);

        // フェードアウト開始(BGMも)
        float time = 0;
        while (true)
        {
            time += Time.deltaTime;

            if (time < OtherParamsSO.Entity.ToTitleWaitTime)
            {
                fadeOutIm.color = new Color(0, 0, 0, time / OtherParamsSO.Entity.ToTitleWaitTime);
                gameBGMAs.volume = OtherParamsSO.Entity.GameBGMVolume * (1 - time / OtherParamsSO.Entity.ToTitleWaitTime);
            }
            else
            {
                SceneManager.LoadScene("Title");
                yield break;
            }

            yield return null;
        }
    }
}