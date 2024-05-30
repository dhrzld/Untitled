using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaycastDisplayInfo : MonoBehaviour
{
    public Text infoText; // InfoText UI 요소를 연결할 변수
    public float displayDuration = 2.0f; // 정보가 화면에 표시될 시간 (초)
    public float maxDistance = 1.0f; // Ray의 최대 거리 (여기서는 1미터로 설정)

    private Coroutine displayCoroutine;

    void Update()
    {
        // 카메라에서 앞으로 향하는 방향으로 Ray 생성
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Raycast 실행
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // 충돌된 오브젝트의 거리가 maxDistance 이하일 때
            if (hit.distance <= maxDistance)
            {
                // 충돌된 오브젝트의 정보를 가져와 UI 텍스트에 표시
                string hitInfo = $"Hit Object: {hit.collider.name}\n" +
                                 $"Position: {hit.point}\n" +
                                 $"Distance: {hit.distance}";
                infoText.text = hitInfo;

                // 기존에 실행 중인 코루틴이 있으면 정지
                if (displayCoroutine != null)
                {
                    StopCoroutine(displayCoroutine);
                }
                // 새로운 코루틴 시작
                displayCoroutine = StartCoroutine(ClearInfoTextAfterDelay(displayDuration));

                // 추가적인 작업을 여기서 수행할 수 있음
                Debug.Log(hitInfo);
            }
        }
        else
        {
            // 아무것도 충돌하지 않았을 때
            infoText.text = "No hit detected.";

            // 기존에 실행 중인 코루틴이 있으면 정지
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }
            // 새로운 코루틴 시작
            displayCoroutine = StartCoroutine(ClearInfoTextAfterDelay(displayDuration));
        }
    }

    // 일정 시간 후 텍스트를 지우는 코루틴
    private IEnumerator ClearInfoTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        infoText.text = "";
    }
}
