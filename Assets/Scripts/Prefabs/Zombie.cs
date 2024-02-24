using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody rb;
    float[] distances;
    public bool IsFromVillager { get; set; } = false;
    public int HP { get; set; }
    public float Speed { get; set; }
    float minX; float minY; float minZ; float maxX; float maxY; float maxZ;
    Vector3 nearestVillagerPos;
    Vector3 nearestZombiePos;
    public bool IsAlone { get; set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HP = VZParamsSO.Entity.ZombieMaxHP;
        Speed = VZParamsSO.Entity.ZombieSpeed;
        distances = new float[GameManager.Instance.VillagerInstances.Length];
        minX = VZParamsSO.Entity.KillLimitPosition[0].x;
        minY = VZParamsSO.Entity.KillLimitPosition[0].y;
        minZ = VZParamsSO.Entity.KillLimitPosition[0].z;
        maxX = VZParamsSO.Entity.KillLimitPosition[1].x;
        maxY = VZParamsSO.Entity.KillLimitPosition[1].y;
        maxZ = VZParamsSO.Entity.KillLimitPosition[1].z;
        StartCoroutine(KillDecide());
        StartCoroutine(RefindVillager());
        StartCoroutine(RefindZombie());
    }

    void Update()
    {
        // �̗͂��Ȃ��Ȃ���
        if (HP <= 0)
        {
            GameManager.Instance.ZombieNumber -= 1;
            gameObject.SetActive(false);
            gameObject.tag = "DiedZombie";
        }

        // �̗͍͂ő�l�𒴂��Ȃ�
        if (HP >= VZParamsSO.Entity.ZombieMaxHP)
        {
            HP = VZParamsSO.Entity.ZombieMaxHP;
        }

        // �]���r���Ǘ����Ă��邩�ǂ���
        if ((transform.position - nearestZombiePos).sqrMagnitude >= Mathf.Pow(VZParamsSO.Entity.ZombieOnAloneMinDistance, 2))
        {
            IsAlone = true;
        }
        else
        {
            IsAlone = false;
        }

        Move();
    }

    // �͈͊O�ɍs�������ǂ�������
    IEnumerator KillDecide()
    {
        while (true)
        {
            if (transform.position.x < minX || maxX < transform.position.x)
            {
                HP = 0;
            }
            else if (transform.position.y < minY || maxY < transform.position.y)
            {
                HP = 0;
            }
            else if (transform.position.z < minZ || maxZ < transform.position.z)
            {
                HP = 0;
            }

            yield return new WaitForSeconds(VZParamsSO.Entity.KillDecidePeriod);
        }
    }

    // ���Ԋu�ōŋߐڂ̑��l��T�����C���̑��l�̍��W��nearestVillagerPos�Ƃ���B
    IEnumerator RefindVillager()
    {
        while (true)
        {
            for (int i = 0; i < GameManager.Instance.VillagerInstances.Length; i++)
            {
                if (GameManager.Instance.VillagerInstances[i].activeSelf)
                {
                    Vector3 villagerPos = GameManager.Instance.VillagerInstances[i].transform.position;
                    distances[i] = (transform.position - villagerPos).sqrMagnitude;
                }
                else
                {
                    distances[i] = 10000;
                }
            }

            GameObject nearestVillager = GameManager.Instance.VillagerInstances[Array.IndexOf(distances, distances.Min())];
            nearestVillagerPos = nearestVillager.transform.position;

            float period = VZParamsSO.Entity.ZombieRefindVillagerPeriod;
            float offset = VZParamsSO.Entity.ZombieRefindVillagerPeriodOffset;
            float thisTimePeriod = UnityEngine.Random.Range(period - offset, period + offset);
            yield return new WaitForSeconds(thisTimePeriod);
        }
    }

    // ���Ԋu�ōŋߐڂ̃]���r(�����ȊO)��T�����C���̃]���r�̍��W��nearestZombiePos�Ƃ���B
    IEnumerator RefindZombie()
    {
        while (true)
        {
            for (int i = 0; i < GameManager.Instance.ZombieInstances.Length; i++)
            {
                if (GameManager.Instance.ZombieInstances[i].activeSelf)
                {
                    Vector3 zombiePos = GameManager.Instance.ZombieInstances[i].transform.position;
                    float distance = (transform.position - zombiePos).sqrMagnitude;
                    // �����Ƃ̋�����0�ɂȂ�B
                    if (distance <= Mathf.Pow(VZParamsSO.Entity.ZombieMaxSelfDistance, 2))
                    {
                        distances[i] = 10000;
                    }
                    else
                    {
                        distances[i] = distance;
                    }
                }
                else
                {
                    distances[i] = 10000;
                }
            }

            GameObject nearestZombie = GameManager.Instance.ZombieInstances[Array.IndexOf(distances, distances.Min())];
            nearestZombiePos = nearestZombie.transform.position;

            yield return new WaitForSeconds(VZParamsSO.Entity.ZombieRefindZombiePeriod);
        }
    }

    // �ǂ�������B
    void Move()
    {
        if (nearestVillagerPos != null)
        {
            // ���l��ǂ�������B
            Vector3 mov;
            if (!IsFromVillager)
            {
                mov = nearestVillagerPos - transform.position;
            }
            else
            {
                // ���l���瓦����
                mov = transform.position - nearestVillagerPos;
            }
            mov.Normalize();
            rb.MovePosition(transform.position + mov * (Speed * Time.deltaTime));
        }
    }
}