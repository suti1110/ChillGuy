using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 20;
    public enum Type
    {
        Normal,
        Boss
    }
    public Type type;

    protected Collider2D[] AttackRange(float Range)
    {
        return Physics2D.OverlapCircleAll(transform.position, Range, 6);
    }
}
