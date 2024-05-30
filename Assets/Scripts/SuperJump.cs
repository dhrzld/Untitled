using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float jumpForce = 10f; // 점프대가 가할 힘의 크기

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 Rigidbody를 가져옵니다.
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Rigidbody가 있다면 위로 힘을 가합니다.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
