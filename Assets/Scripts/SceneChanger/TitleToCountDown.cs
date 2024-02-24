using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToCountDown : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("CountDown");
    }
}