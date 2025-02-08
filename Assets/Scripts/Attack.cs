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
    GameObject Enemy;
    float LookingTime = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ChillGage = 100;
        if (GameObject.Find("EvilGuy") != null) Enemy = GameObject.Find("EvilGuy");
    }

    private void Update()
    {
        if (rb.velocity.x != 0 && Input.GetKeyDown(KeyCode.J) && ChillGage >= 30)
        {
            ChillGage -= 30;
            DOTween.To(() => transform.position, x => transform.position = x, new Vector3(transform.position.x + (rb.velocity.x > 0 ? 1 : rb.velocity.x < 0 ? -1 : 0) * 10, transform.position.y), DashTime);
            StartCoroutine(Dash());
        }
        if (Enemy != null && Input.GetKey(KeyCode.K))
        {
            if (Enemy.transform.position.x - transform.position.x > 0 && GetComponent<SpriteRenderer>().flipX)
            {

            }
            else if (Enemy.transform.position.x - transform.position.x < 0 && !GetComponent<SpriteRenderer>().flipX)
            {

            }
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
