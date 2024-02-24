using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Villager : MonoBehaviour
{
    Rigidbody rb;
    float[] distances;
    public bool IsToZombie { get; set; } = false;
    public int HP { get; set; }
    public float Speed { get; set; }
    public bool IsDamagableFromZombie { get; set; } = true;
    float minX; float minY; float minZ; float maxX; float maxY; float maxZ;
    Vector3 nearestZombiePos;
    float randomTheta;
    public bool IsAtCorner { get; set; } = false;
    bool isHitWallH = false;
    bool isHitWallV = false;
    bool isHitZombie = false;
    bool isDamagable = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HP = VZParamsSO.Entity.VillagerMaxHP;
        Speed = VZParamsSO.Entity.VillagerSpeed;
        distances = new float[GameManager.Instance.ZombieInstances.Length];
        minX = VZParamsSO.Entity.KillLimitPosition[0].x;
        minY = VZParamsSO.Entity.KillLimitPosition[0].y;
        minZ = VZParamsSO.Entity.KillLimitPosition[0].z;
        maxX = VZParamsSO.Entity.KillLimitPosition[1].x;
        maxY = VZParamsSO.Entity.KillLimitPosition[1].y;
        maxZ = VZParamsSO.Entity.KillLimitPosition[1].z;
        StartCoroutine(KillDecide());
        StartCoroutine(RefindZombie());
    }

    void Update()
    {
        // 体力がなくなった
        if (HP <= 0)
        {
            GameManager.Instance.VillagerNumber -= 1;
            gameObject.SetActive(false);
            gameObject.tag = "DiedVillager";
        }

        // 体力は最大値を超えない
        if (HP >= VZParamsSO.Entity.VillagerMaxHP)
        {
            HP = VZParamsSO.Entity.VillagerMaxHP;
        }

        // ゾンビに接触した
        if (isHitZombie && isDamagable)
        {
            isHitZombie = false;
            
            if (IsDamagableFromZombie)
            {
                isDamagable = false;
                HP -= VZParamsSO.Entity.ZombieAttackPower;
                StartCoroutine(DamagingCount());
            }
        }

        // 角にいる判定
        if (isHitWallH && isHitWallV)
        {
            IsAtCorner = true;
        }
        else
        {
            IsAtCorner = false;
        }

        // オーラ3が発動されたら強制的に半透明にする
        if (!IsDamagableFromZombie)
        {
            StopCoroutine(DamagingCount());
            isDamagable = true;
            GetComponent<Renderer>().material.color = new Color(1, 1, 0, 100 / (float)255);
        }
        else if (isDamagable)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 0, 1);
        }

        Move();
    }

    // 範囲外に行ったかどうか判定
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

    // 一定間隔で最近接のゾンビを探査し，そのゾンビの座標をnearestZombiePosとする。
    IEnumerator RefindZombie()
    {
        while (true)
        {
            for (int i = 0; i < GameManager.Instance.ZombieInstances.Length; i++)
            {
                if (GameManager.Instance.ZombieInstances[i].activeSelf)
                {
                    Vector3 zombiePos = GameManager.Instance.ZombieInstances[i].transform.position;
                    distances[i] = (transform.position - zombiePos).sqrMagnitude;
                }
                else
                {
                    distances[i] = 10000;
                }
            }

            GameObject nearestZombie = GameManager.Instance.ZombieInstances[Array.IndexOf(distances, distances.Min())];
            nearestZombiePos = nearestZombie.transform.position;

            // ランダムな回転角も更新
            float p = UnityEngine.Random.Range(0f, 1f);
            float thetaCoefMin = VZParamsSO.Entity.RandomThetaCoefRange[0];
            float thetaCoefMax = VZParamsSO.Entity.RandomThetaCoefRange[1];

            if (p < VZParamsSO.Entity.RandomThetaOutOfRangeP)
            {
                float randomTheta1 = UnityEngine.Random.Range(Mathf.PI * (-1), Mathf.PI * thetaCoefMin) * Mathf.Rad2Deg;
                float randomTheta2 = UnityEngine.Random.Range(Mathf.PI * thetaCoefMax, Mathf.PI * 1) * Mathf.Rad2Deg;
                int _p = UnityEngine.Random.Range(0, 2);
                if (_p == 0) { randomTheta = randomTheta1; }
                else { randomTheta = randomTheta2; }
            }
            else
            {
                randomTheta = UnityEngine.Random.Range(Mathf.PI * thetaCoefMin, Mathf.PI * thetaCoefMax) * Mathf.Rad2Deg;
            }

            float period = VZParamsSO.Entity.VillagerRefindPeriod;
            float offset = VZParamsSO.Entity.VillagerRefindPeriodOffset;
            float thisTimePeriod = UnityEngine.Random.Range(period - offset, period + offset);
            yield return new WaitForSeconds(thisTimePeriod);
        }
    }
    
    // 村人は一定間隔でしかダメージを食らえない。被ダメージ時に赤くする。
    IEnumerator DamagingCount()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(VZParamsSO.Entity.VillagerDamagePeriod);
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 1);
        isDamagable = true;
        yield break;
    }
    
    // 逃げる。
    void Move()
    {
        if (nearestZombiePos != null)
        {
            // ゾンビから逃げる。ただしランダムに回転した方向になる。
            Vector3 mov;
            if (!IsToZombie)
            {
                mov = Quaternion.Euler(0, randomTheta, 0) * (transform.position - nearestZombiePos).normalized;
            }
            else
            {
                // ゾンビを追いかける
                mov = (nearestZombiePos - transform.position).normalized;
            }
            rb.MovePosition(transform.position + mov * (Speed * Time.deltaTime));
        }
    }

    // ゾンビ，壁との当たり判定
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            isHitZombie = true;
        }
        else if (collision.gameObject.tag == "WallH")
        {
            isHitWallH = true;
        }
        else if (collision.gameObject.tag == "WallV")
        {
            isHitWallV = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "WallH")
        {
            isHitWallH = false;
        }
        else if (collision.gameObject.tag == "WallV")
        {
            isHitWallV = false;
        }
    }
}
