using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    SpriteRenderer spriter;
    Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;
    bool isGround = false;

    private void Awake()
    {
        rb  = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
        if (rb.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = true;
        else if (rb.velocity.x < 0) GetComponent<SpriteRenderer>().flipX = false;
    }

    private void Update()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, Input.GetAxisRaw("Vertical") * JumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
        if (rb.velocity == Vector2.zero)
        {
            Attack.ChillGage += 10 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }


}
