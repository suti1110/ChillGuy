using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageManager : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().DOColor(new Color(255, 255, 255, 0), 0.2f);
        Destroy(gameObject, 0.2f);
    }
}
