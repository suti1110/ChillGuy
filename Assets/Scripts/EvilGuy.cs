using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilGuy : Enemy
{
    float attackPendingTime = 0;
    bool randomReset = false;
    int direction = 0;
    public float Centre = 0;
    public float Size = 25;
    Animator anim;
    public Sprite JumpTiming;
    Transform player;
    public GameObject particle;
    public GameObject ChillLi;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackPendingTime > 0)
        {
            attackPendingTime -= Time.deltaTime;
        }

        if (attackPendingTime <= 0)
        {
            anim.SetBool("Walking", false);
            Collider2D[] hitColliders1 = AttackRange(2f);
            Collider2D[] hitColliders2 = AttackRange(6f);
            if (hitColliders2.Length > 0)
            {
                if (hitColliders1.Length > 0)
                {
                    attackPendingTime = 0.75f;
                    anim.SetTrigger("ShortAttack");
                    GetComponent<SpriteRenderer>().flipX = transform.position.x - player.position.x < 0;
                    StartCoroutine(WaitAction.wait(0.15f, () =>
                    {
                        if (hitColliders1.Length > 0)
                        {
                            player.GetComponent<GetDamage>().ApplyDamage();
                        }
                    }));
                }
                else
                {
                    attackPendingTime = 1.5f;
                    anim.SetTrigger("MidAttack");
                    GetComponent<SpriteRenderer>().flipX = transform.position.x - player.position.x < 0;
                    StartCoroutine(WaitAction.wait(0.2f, () =>
                    {
                        Instantiate(ChillLi, transform.position, Quaternion.identity);
                    }));
                }
            }
            else
            {
                attackPendingTime = 3f;
                anim.SetTrigger("LongAttack");
                StartCoroutine(WaitAction.wait(() => { return gameObject.GetComponent<SpriteRenderer>().sprite == JumpTiming; }, () =>
                {
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    rb.gravityScale = 0;
                    DOTween.To(() => transform.position, x => transform.position = x, new Vector3(player.position.x, player.position.y + 5), 0.5f);
                    StartCoroutine(WaitAction.wait(0.5f, () =>
                    {
                        rb.velocity = new Vector2(0, -50);
                        StartCoroutine(WaitAction.wait(0.1f, () =>
                        {
                            particle.GetComponent<ParticleSystem>().Play();
                            rb.gravityScale = 1;
                        }));
                    }));
                }));
            }
        }
        else
        {
            Move();
        }
    }

    protected override void Move()
    {
        if (!randomReset)
        {
            randomReset = true;
            StartCoroutine(WaitAction.wait(1f, () =>
            {
                direction = Random.Range(-1, 2);
                randomReset = false;
                gameObject.GetComponent<SpriteRenderer>().flipX = direction == 1;
            }));
        }
        anim.SetBool("Walking", direction == 0);
        transform.Translate(direction * MoveSpeed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(transform.position.x) >= Size)
        {
            direction = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<GetDamage>().ApplyDamage();
        }
    }
}
