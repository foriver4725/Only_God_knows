using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownToGameStage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] AudioClip countDownOnceSE;
    GameObject titleBGM;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // BGMの音を小さくする
        titleBGM = GameObject.FindGameObjectsWithTag("TitleBGM")[0];
        titleBGM.GetComponent<AudioSource>().volume *= OtherParamsSO.Entity.OnCountDownTitleBGMVolumeRatio;

        StartCoroutine(DoCountDown(OtherParamsSO.Entity.CountDownLength));
    }

    // カウントダウンをする。
    IEnumerator DoCountDown(int times)
    {
        for (int i = times; i > 0; i--)
        {
            countDownText.text = $"{i}";
            audioSource.PlayOneShot(countDownOnceSE);

            yield return new WaitForSeconds(1);
        }

        // カウントダウンが終わったら，BGMを再生しているゲームオブジェクトを完全に削除
        Destroy(titleBGM);

        SceneManager.LoadScene("GameStage");

        yield break;
    }
}
