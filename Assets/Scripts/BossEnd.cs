using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : Dialogue
{
    public void GameClear()
    {
        printLog(comunities[0].name, comunities[0].dialogue);
        StartCoroutine(WaitAction.wait(() => { return !talking; }, () =>
        {
            FadeInOut.SceneChange("GameClear");
        }));
    }
}
