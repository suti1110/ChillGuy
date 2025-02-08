using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // 장애물에 충돌한 Player 오브젝트를 감지하고 GetDamage 호출
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player와 충돌 시 GetDamage 함수 호출
            collision.gameObject.GetComponent<GetDamage>().ApplyDamage();
        }
    }
}
