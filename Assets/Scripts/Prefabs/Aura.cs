using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FadeCount());
    }

    void Update()
    {
        // プレイヤーに触れられたら消す
        if (GameManager.Instance.IsToDestroyAura)
        {
            GameManager.Instance.IsToDestroyAura = false;

            Destroy(gameObject);
        }
    }

    // 出現から一定時間経過したら消える
    IEnumerator FadeCount()
    {
        yield return new WaitForSeconds(AuraParamsSO.Entity.AuraAppearTime);
        Destroy(gameObject);
        yield break;
    }
}
