using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillLiMove : MonoBehaviour
{
    Transform player;
    public GameObject effect;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<Rigidbody2D>().velocity = new Vector2((transform.position.x - player.position.x < 0 ? 1 : -1) * 10, 0);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360 * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<GetDamage>().ApplyDamage();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
