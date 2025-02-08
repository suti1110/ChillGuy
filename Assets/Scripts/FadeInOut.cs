using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System;
using DG.Tweening.Core;

public class FadeInOut : MonoBehaviour
{
    static Image image;
    static Action<string> action;
    static TweenerCore<Color, Color, DG.Tweening.Plugins.Options.ColorOptions> tweening;

    private void Awake()
    {
        image = GetComponent<Image>();
        action = (s) =>
        {
            StartCoroutine(WaitAction.wait(() => { return !tweening.IsPlaying(); }, () =>
            {
                SceneManager.LoadScene(s);
            }));
        };
        StartCoroutine(WaitAction.wait(0.3f, () =>
        {
            tweening = image.DOColor(new Color(0, 0, 0, 0), 0.5f);
            StartCoroutine(WaitAction.wait(() => { return !tweening.IsPlaying(); }, () =>
            {
                image.gameObject.SetActive(false);
            }));
        }));
    }

    public static void SceneChange(string SceneName)
    {
        image.gameObject.SetActive(true);
        tweening = image.DOColor(new Color(0, 0, 0, 1), 0.5f);
        action.Invoke(SceneName);
    }
}
