using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int HP = 20;
    public enum Type
    {
        Normal,
        Boss
    }
    public Type type;
    public float MoveSpeed;
    public LayerMask layerMask;

    protected abstract void Move();

    protected Collider2D[] AttackRange(float Range)
    {
        return Physics2D.OverlapCircleAll(transform.position, Range, layerMask);
    }
}
