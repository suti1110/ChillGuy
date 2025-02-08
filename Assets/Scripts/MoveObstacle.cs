using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float speed = 1f;  // 이동 속도 (초당 증가하는 y 값)
    private float targetHeight;  // 목표 y 값 (현재 y 값에 0.8을 더한 값)
    private float originalHeight;  // 원래 y 값
    private bool isGoingUp = true;  // 올라가는지 내려가는지 여부

    private void Start()
    {
        // 현재 위치에서 y 값을 0.8만큼 더한 목표 위치 설정
        originalHeight = transform.position.y;  // 원래 위치 저장
        targetHeight = originalHeight + 0.8f;  // 목표 위치 설정
    }

    private void Update()
    {
        if (isGoingUp)
        {
            // 올라가는 중: 목표 y 값에 도달하면 내려가기 시작
            if (transform.position.y < targetHeight)
            {
                float newY = Mathf.MoveTowards(transform.position.y, targetHeight, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                isGoingUp = false;  // 올라갔다면 내려가기 시작
            }
        }
        else
        {
            // 내려가는 중: 원래 자리로 돌아오기
            if (transform.position.y > originalHeight)
            {
                float newY = Mathf.MoveTowards(transform.position.y, originalHeight, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                isGoingUp = true;  // 원래 위치에 도달하면 다시 올라가기 시작
            }
        }
    }
}
