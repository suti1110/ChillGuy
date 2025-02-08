using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaitAction
{
    public static IEnumerator wait(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action.Invoke();
    }

    public static IEnumerator wait(Func<bool> condition, Action action)
    {
        yield return new WaitUntil(condition);
        action.Invoke();
    }
}
