using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float jumpForce = 10f; // �����밡 ���� ���� ũ��

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Rigidbody�� �����ɴϴ�.
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Rigidbody�� �ִٸ� ���� ���� ���մϴ�.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
