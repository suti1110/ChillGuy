using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObstacle : MonoBehaviour
{
    public float fallSpeed = 5f; // 하강 속도
    public Vector3 startPosition; // 원래 위치
    private bool isFalling = true; // 장애물이 하강 중인지 여부

    private void Start()
    {
        // 장애물이 처음 시작할 때 위치를 설정
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isFalling)
        {
            // 장애물이 아래로 하강
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // Ground에 닿으면 다시 원래 위치로 돌아가기
            if (transform.position.y <= 0)  // Ground의 y 위치를 0으로 가정
            {
                // 위치를 원래 위치로 되돌리고 다시 하강 준비
                transform.position = startPosition;
                isFalling = false;
                // 잠시 멈췄다가 다시 하강 시작
                Invoke("StartFalling", 1f); // 1초 후 하강 시작
            }
        }
    }

    private void StartFalling()
    {
        isFalling = true;
    }
}
