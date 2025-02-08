using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 20;

    protected Collider2D AttackRange(float Range)
    {
        return Physics2D.OverlapCircle(transform.position, Range);
    }
}
