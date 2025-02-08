using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public Vector2 originalPosition;  // ���� ��ġ�� ������ ����
    public float fallSpeed = 5f;      // �ϰ� �ӵ�

    void Start()
    {
        originalPosition = transform.position;  // ���� �� ���� ��ġ�� ���
    }

    void Update()
    {
        // �Ʒ��� �ϰ�
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground�� �浹�ϸ� ���� ��ġ�� �ǵ�����
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = originalPosition;
        }
    }
}
