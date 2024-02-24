using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToTutorial1 : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}