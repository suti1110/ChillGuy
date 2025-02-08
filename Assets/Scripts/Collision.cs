using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // ��ֹ��� �浹�� Player ������Ʈ�� �����ϰ� GetDamage ȣ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player�� �浹 �� GetDamage �Լ� ȣ��
            collision.gameObject.GetComponent<GetDamage>().ApplyDamage();
        }
    }
}
