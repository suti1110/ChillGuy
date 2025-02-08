using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

public class BeforeStory : MonoBehaviour
{
    public string SceneName;

    private void Awake()
    {
        var tweening = DOTween.To(() => transform.position, x => transform.position = x, new Vector3(transform.position.x, transform.position.y + 5000), 10f);
        StartCoroutine(WaitAction.wait(() => { return !tweening.IsPlaying(); }, () =>
        {
            FadeInOut.SceneChange(SceneName);
        }));
    }
}
