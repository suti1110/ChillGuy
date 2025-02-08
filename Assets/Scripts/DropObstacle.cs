using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObstacle : MonoBehaviour
{
    public float fallSpeed = 5f; // �ϰ� �ӵ�
    public Vector3 startPosition; // ���� ��ġ
    private bool isFalling = true; // ��ֹ��� �ϰ� ������ ����

    private void Start()
    {
        // ��ֹ��� ó�� ������ �� ��ġ�� ����
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isFalling)
        {
            // ��ֹ��� �Ʒ��� �ϰ�
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // Ground�� ������ �ٽ� ���� ��ġ�� ���ư���
            if (transform.position.y <= 0)  // Ground�� y ��ġ�� 0���� ����
            {
                // ��ġ�� ���� ��ġ�� �ǵ����� �ٽ� �ϰ� �غ�
                transform.position = startPosition;
                isFalling = false;
                // ��� ����ٰ� �ٽ� �ϰ� ����
                Invoke("StartFalling", 1f); // 1�� �� �ϰ� ����
            }
        }
    }

    private void StartFalling()
    {
        isFalling = true;
    }
}
