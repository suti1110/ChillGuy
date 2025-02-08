using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilGuy : Enemy
{
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders1 = AttackRange(2f);
        Collider2D[] hitColliders2 = AttackRange(4f);
    }
}
