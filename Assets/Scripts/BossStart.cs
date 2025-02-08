using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : Dialogue
{
    private void Awake()
    {
        printLog(comunities[0].name, comunities[0].dialogue);
    }
}
