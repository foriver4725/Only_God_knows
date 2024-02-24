using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    float minX; float minY; float minZ; float maxX; float maxY; float maxZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        minX = VZParamsSO.Entity.KillLimitPosition[0].x;
        minY = VZParamsSO.Entity.KillLimitPosition[0].y;
        minZ = VZParamsSO.Entity.KillLimitPosition[0].z;
        maxX = VZParamsSO.Entity.KillLimitPosition[1].x;
        maxY = VZParamsSO.Entity.KillLimitPosition[1].y;
        maxZ = VZParamsSO.Entity.KillLimitPosition[1].z;
        StartCoroutine(WarpBackDecide());
    }

    void Update()
    {
        // 入力検知
        float inputX = Input.GetAxis("Horizontal"); // 左右
        float inputZ = Input.GetAxis("Vertical"); // 上下

        // 移動
        Vector3 movement = new Vector3(inputX, 0, inputZ); // 運動ベクトル
        if (movement.magnitude > 1.0f)
        {
            movement.Normalize(); // 運動ベクトルを正規化
        }
        Vector3 position = rb.position; // 位置ベクトル
        rb.MovePosition(position + movement * (OtherParamsSO.Entity.PlayerSpeed * Time.deltaTime));
    }

    // 範囲外に行ったかどうか判定
    IEnumerator WarpBackDecide()
    {
        while (true)
        {
            if (transform.position.x < minX || maxX < transform.position.x)
            {
                transform.position = new Vector3(0, 1, 0);
            }
            else if (transform.position.y < minY || maxY < transform.position.y)
            {
                transform.position = new Vector3(0, 1, 0);
            }
            else if (transform.position.z < minZ || maxZ < transform.position.z)
            {
                transform.position = new Vector3(0, 1, 0);
            }

            yield return new WaitForSeconds(VZParamsSO.Entity.KillDecidePeriod);
        }
    }

    // オーラに触れた
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Aura")
        {
            GameManager.Instance.IsToDestroyAura = true;
            GameManager.Instance.IsGetAura = true;
        }
    }
}
