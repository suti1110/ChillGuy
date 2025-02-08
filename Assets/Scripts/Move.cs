using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;

    private void Awake()
    {
        rb  = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }
}
