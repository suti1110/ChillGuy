using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public Vector2 originalPosition;  // 원래 위치를 저장할 변수
    public float fallSpeed = 5f;      // 하강 속도

    void Start()
    {
        originalPosition = transform.position;  // 시작 시 원래 위치를 기록
    }

    void Update()
    {
        // 아래로 하강
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground와 충돌하면 원래 위치로 되돌리기
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = originalPosition;
        }
    }
}
