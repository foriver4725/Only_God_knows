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
        // �v���C���[�ɐG���ꂽ�����
        if (GameManager.Instance.IsToDestroyAura)
        {
            GameManager.Instance.IsToDestroyAura = false;

            Destroy(gameObject);
        }
    }

    // �o�������莞�Ԍo�߂����������
    IEnumerator FadeCount()
    {
        yield return new WaitForSeconds(AuraParamsSO.Entity.AuraAppearTime);
        Destroy(gameObject);
        yield break;
    }
}
