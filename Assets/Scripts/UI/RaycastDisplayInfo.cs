using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaycastDisplayInfo : MonoBehaviour
{
    public Text infoText; // InfoText UI ��Ҹ� ������ ����
    public float displayDuration = 2.0f; // ������ ȭ�鿡 ǥ�õ� �ð� (��)
    public float maxDistance = 1.0f; // Ray�� �ִ� �Ÿ� (���⼭�� 1���ͷ� ����)

    private Coroutine displayCoroutine;

    void Update()
    {
        // ī�޶󿡼� ������ ���ϴ� �������� Ray ����
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Raycast ����
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // �浹�� ������Ʈ�� �Ÿ��� maxDistance ������ ��
            if (hit.distance <= maxDistance)
            {
                // �浹�� ������Ʈ�� ������ ������ UI �ؽ�Ʈ�� ǥ��
                string hitInfo = $"Hit Object: {hit.collider.name}\n" +
                                 $"Position: {hit.point}\n" +
                                 $"Distance: {hit.distance}";
                infoText.text = hitInfo;

                // ������ ���� ���� �ڷ�ƾ�� ������ ����
                if (displayCoroutine != null)
                {
                    StopCoroutine(displayCoroutine);
                }
                // ���ο� �ڷ�ƾ ����
                displayCoroutine = StartCoroutine(ClearInfoTextAfterDelay(displayDuration));

                // �߰����� �۾��� ���⼭ ������ �� ����
                Debug.Log(hitInfo);
            }
        }
        else
        {
            // �ƹ��͵� �浹���� �ʾ��� ��
            infoText.text = "No hit detected.";

            // ������ ���� ���� �ڷ�ƾ�� ������ ����
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }
            // ���ο� �ڷ�ƾ ����
            displayCoroutine = StartCoroutine(ClearInfoTextAfterDelay(displayDuration));
        }
    }

    // ���� �ð� �� �ؽ�Ʈ�� ����� �ڷ�ƾ
    private IEnumerator ClearInfoTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        infoText.text = "";
    }
}
