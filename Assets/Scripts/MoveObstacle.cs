using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float speed = 1f;  // �̵� �ӵ� (�ʴ� �����ϴ� y ��)
    private float targetHeight;  // ��ǥ y �� (���� y ���� 0.8�� ���� ��)
    private float originalHeight;  // ���� y ��
    private bool isGoingUp = true;  // �ö󰡴��� ���������� ����

    private void Start()
    {
        // ���� ��ġ���� y ���� 0.8��ŭ ���� ��ǥ ��ġ ����
        originalHeight = transform.position.y;  // ���� ��ġ ����
        targetHeight = originalHeight + 0.8f;  // ��ǥ ��ġ ����
    }

    private void Update()
    {
        if (isGoingUp)
        {
            // �ö󰡴� ��: ��ǥ y ���� �����ϸ� �������� ����
            if (transform.position.y < targetHeight)
            {
                float newY = Mathf.MoveTowards(transform.position.y, targetHeight, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                isGoingUp = false;  // �ö󰬴ٸ� �������� ����
            }
        }
        else
        {
            // �������� ��: ���� �ڸ��� ���ƿ���
            if (transform.position.y > originalHeight)
            {
                float newY = Mathf.MoveTowards(transform.position.y, originalHeight, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                isGoingUp = true;  // ���� ��ġ�� �����ϸ� �ٽ� �ö󰡱� ����
            }
        }
    }
}
