using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial1ToTutorial2 : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Tutorial2");
    }
}
