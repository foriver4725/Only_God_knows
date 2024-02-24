using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGM : MonoBehaviour
{
    void Start()
    {
        // ���ł�BGM���Đ����̃Q�[���I�u�W�F�N�g����������C���g������
        if (GameObject.FindGameObjectsWithTag("TitleBGM").Length > 1)
        {
            Destroy(gameObject);
        }
        // BGM���Đ�
        else
        {
            DontDestroyOnLoad(gameObject);

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}
