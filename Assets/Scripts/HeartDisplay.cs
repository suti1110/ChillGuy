using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public GetDamage getDamageScript;  // GetDamage 스크립트를 참조
    public GameObject heartPrefab;     // 하트 프리팹
    public Transform heartContainer;   // 하트를 배치할 위치 (보통 UI에 배치)
    GameObject[] Hearts = new GameObject[3];

    private void Start()
    {
        // 하트 프리팹과 위치를 설정합니다.
        if (heartPrefab == null || heartContainer == null)
        {
            Debug.LogError("하트 프리팹이나 위치 컨테이너가 설정되지 않았습니다.");
            return;
        }

        // 하트 표시 초기화
        UpdateHeartDisplay();
    }

    public void UpdateHeartDisplay()
    {
        if (Hearts.Length != 0)
        {
            for (int i = 0; i < Hearts.Length; i++)
            {
                Destroy(Hearts[i]);
                // 하트 위치를 조정하거나 추가적인 설정을 할 수 있습니다.
            }
        }

        // 현재 Hearth 수에 맞는 하트를 추가
        for (int i = 0; i < getDamageScript.health; i++)
        {
            Hearts[i] = Instantiate(heartPrefab, heartContainer.position + new Vector3(i * 70, 0), Quaternion.identity);
            Hearts[i].transform.parent = transform;
            // 하트 위치를 조정하거나 추가적인 설정을 할 수 있습니다.
        }
    }
}
