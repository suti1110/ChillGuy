using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject AfterImage;
    float DashTime = 0.5f;
    Rigidbody2D rb;
    public static float ChillGage = 100;
    public GameObject[] EyesLights;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ChillGage = 100;
    }

    private void Update()
    {
        if (rb.velocity.x != 0 && Input.GetKeyDown(KeyCode.J) && ChillGage >= 30)
        {
            ChillGage -= 30;
            DOTween.To(() => transform.position, x => transform.position = x, new Vector3(transform.position.x + (rb.velocity.x > 0 ? 1 : rb.velocity.x < 0 ? -1 : 0) * 10, transform.position.y), DashTime);
            StartCoroutine(Dash());
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                EyesLights[0].SetActive(true);
                EyesLights[0].transform.rotation = Quaternion.Euler(0, 90, -90);
                EyesLights[1].SetActive(true);
                EyesLights[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                EyesLights[1].transform.position = new Vector3(transform.position.x + 17.14f, transform.position.y, transform.position.z);
            }
            else if (!GetComponent<SpriteRenderer>().flipX)
            {
                EyesLights[0].SetActive(true);
                EyesLights[0].transform.rotation = Quaternion.Euler(180, 90, -90);
                EyesLights[1].SetActive(true);
                EyesLights[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                EyesLights[1].transform.position = new Vector3(transform.position.x - 17.14f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            EyesLights[0].SetActive(false);
            EyesLights[1].SetActive(false);
        }
    }

    IEnumerator Dash()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(AfterImage, transform.position, Quaternion.identity);
            SpriteRenderer temp2 = temp.GetComponent<SpriteRenderer>();
            temp2 = GetComponent<SpriteRenderer>();
            yield return new WaitForSeconds(DashTime / 10);
        }
    }
}
