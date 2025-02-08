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
    Animator anim;
    public AudioClip walkingSound;
    private AudioSource audioSource;
    private bool isWalking;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Move the character horizontally based on input
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);

        // Flip the sprite depending on the movement direction
        if (rb.velocity.x > 0)
            spriter.flipX = true;
        else if (rb.velocity.x < 0)
            spriter.flipX = false;

        // Set the "isMoving" animation parameter based on whether the character is moving
        anim.SetBool("isMoving", rb.velocity.x != 0);

        // Play walking sound when moving and stop when not
        if (rb.velocity.x != 0 && !audioSource.isPlaying && isGround)
        {
            audioSource.PlayOneShot(walkingSound); // Play walking sound
        }
        else if (rb.velocity.x == 0 && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop walking sound
        }
    }

    private void Update()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, Input.GetAxisRaw("Vertical") * JumpForce), ForceMode2D.Impulse);
            isGround = false;
            anim.SetBool("isJumping", true);
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
            anim.SetBool("isJumping", false);
        }
    }
}
