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

        // BGM�̉�������������
        titleBGM = GameObject.FindGameObjectsWithTag("TitleBGM")[0];
        titleBGM.GetComponent<AudioSource>().volume *= OtherParamsSO.Entity.OnCountDownTitleBGMVolumeRatio;

        StartCoroutine(DoCountDown(OtherParamsSO.Entity.CountDownLength));
    }

    // �J�E���g�_�E��������B
    IEnumerator DoCountDown(int times)
    {
        for (int i = times; i > 0; i--)
        {
            countDownText.text = $"{i}";
            audioSource.PlayOneShot(countDownOnceSE);

            yield return new WaitForSeconds(1);
        }

        // �J�E���g�_�E�����I�������CBGM���Đ����Ă���Q�[���I�u�W�F�N�g�����S�ɍ폜
        Destroy(titleBGM);

        SceneManager.LoadScene("GameStage");

        yield break;
    }
}
