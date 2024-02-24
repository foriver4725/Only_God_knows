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
        // ���͌��m
        float inputX = Input.GetAxis("Horizontal"); // ���E
        float inputZ = Input.GetAxis("Vertical"); // �㉺

        // �ړ�
        Vector3 movement = new Vector3(inputX, 0, inputZ); // �^���x�N�g��
        if (movement.magnitude > 1.0f)
        {
            movement.Normalize(); // �^���x�N�g���𐳋K��
        }
        Vector3 position = rb.position; // �ʒu�x�N�g��
        rb.MovePosition(position + movement * (OtherParamsSO.Entity.PlayerSpeed * Time.deltaTime));
    }

    // �͈͊O�ɍs�������ǂ�������
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

    // �I�[���ɐG�ꂽ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Aura")
        {
            GameManager.Instance.IsToDestroyAura = true;
            GameManager.Instance.IsGetAura = true;
        }
    }
}
