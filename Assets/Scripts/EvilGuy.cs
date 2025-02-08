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

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
            Collider2D[] hitColliders1 = AttackRange(1.5f);
            Collider2D[] hitColliders2 = AttackRange(6f);
            if (hitColliders2.Length > 0)
            {
                if (hitColliders1.Length > 0)
                {
                    attackPendingTime = 0.75f;
                    StartCoroutine(WaitAction.wait(0.2f, () =>
                    {
                        if (hitColliders1.Length > 0)
                        {
                            anim.SetTrigger("ShortAttack");
                            Debug.Log("플레이어 데미지!");
                        }
                    }));
                }
                else
                {
                    attackPendingTime = 1.5f;
                    StartCoroutine(WaitAction.wait(0.25f, () =>
                    {
                        Debug.Log("Chill리 소스 소환");
                    }));
                }
            }
            else
            {
                attackPendingTime = 3f;
                Debug.Log("점프 공격!");
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
            Debug.Log("플레이어 데미지");
        }
    }
}
