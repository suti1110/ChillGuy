using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public GetDamage getDamageScript;  // GetDamage ��ũ��Ʈ�� ����
    public GameObject heartPrefab;     // ��Ʈ ������
    public Transform heartContainer;   // ��Ʈ�� ��ġ�� ��ġ (���� UI�� ��ġ)
    GameObject[] Hearts = new GameObject[3];

    private void Start()
    {
        // ��Ʈ �����հ� ��ġ�� �����մϴ�.
        if (heartPrefab == null || heartContainer == null)
        {
            Debug.LogError("��Ʈ �������̳� ��ġ �����̳ʰ� �������� �ʾҽ��ϴ�.");
            return;
        }

        // ��Ʈ ǥ�� �ʱ�ȭ
        UpdateHeartDisplay();
    }

    public void UpdateHeartDisplay()
    {
        if (Hearts.Length != 0)
        {
            for (int i = 0; i < Hearts.Length; i++)
            {
                Destroy(Hearts[i]);
                // ��Ʈ ��ġ�� �����ϰų� �߰����� ������ �� �� �ֽ��ϴ�.
            }
        }

        // ���� Hearth ���� �´� ��Ʈ�� �߰�
        for (int i = 0; i < getDamageScript.health; i++)
        {
            Hearts[i] = Instantiate(heartPrefab, heartContainer.position + new Vector3(i * 70, 0), Quaternion.identity);
            Hearts[i].transform.parent = transform;
            // ��Ʈ ��ġ�� �����ϰų� �߰����� ������ �� �� �ֽ��ϴ�.
        }
    }
}
