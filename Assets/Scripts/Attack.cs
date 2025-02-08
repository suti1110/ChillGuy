using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject AfterImage;
    float DashTime = 0.5f;
    Rigidbody2D rb;
    public static float ChillGage = 100;
    public GameObject[] EyesLights;
    GameObject Enemy;
    public Image image;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ChillGage = 100;
        Enemy = GameObject.Find("EvilGuy");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && ChillGage >= 30)
        {
            ChillGage -= 30;
            DOTween.To(() => transform.position, x => transform.position = x, new Vector3(transform.position.x + (GetComponent<SpriteRenderer>().flipX ? 1 : -1) * 10, transform.position.y), DashTime);
            StartCoroutine(Dash());
        }
        if (Enemy != null && Input.GetKey(KeyCode.K))
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                EyesLights[0].SetActive(true);
                EyesLights[0].transform.rotation = Quaternion.Euler(0, 90, -90);
                EyesLights[1].SetActive(true);
                EyesLights[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                EyesLights[1].transform.position = new Vector3(transform.position.x + 17.14f, transform.position.y + 0.62f, transform.position.z);
            }
            else if (!GetComponent<SpriteRenderer>().flipX)
            {
                EyesLights[0].SetActive(true);
                EyesLights[0].transform.rotation = Quaternion.Euler(180, 90, -90);
                EyesLights[1].SetActive(true);
                EyesLights[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                EyesLights[1].transform.position = new Vector3(transform.position.x - 17.14f, transform.position.y + 0.62f, transform.position.z);
            }
        }
        else
        {
            EyesLights[0].SetActive(false);
            EyesLights[1].SetActive(false);
        }
        image.fillAmount = ChillGage / 100f;
    }

    IEnumerator Dash()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(AfterImage, transform.position, Quaternion.identity);
            temp.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            temp.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
            yield return new WaitForSeconds(DashTime / 10);
        }
    }
}
