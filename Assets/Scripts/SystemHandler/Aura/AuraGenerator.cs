using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraGenerator : MonoBehaviour
{
    [SerializeField] GameObject auraPrfb;

    void Start()
    {
        StartCoroutine(AuraGenerate());
    }

    // ���Ԋu�ŃI�[���𐶐�
    IEnumerator AuraGenerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(AuraParamsSO.Entity.AuraGeneratePeriod);

            float spawnX = Random.Range(AuraParamsSO.Entity.AuraXRange.x, AuraParamsSO.Entity.AuraXRange.y);
            float spawnZ = Random.Range(AuraParamsSO.Entity.AuraZRange.x, AuraParamsSO.Entity.AuraZRange.y);
            Instantiate(auraPrfb, new Vector3(spawnX, 0, spawnZ), Quaternion.identity);
        }
    }
}
