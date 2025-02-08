using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public List<Comunity> comunities;
    public GameObject panel;
    public Text Name;
    public Text Log;
    public Image image;
    TweenerCore<string, string, DG.Tweening.Plugins.Options.StringOptions> tweenerCore;
    public static bool talking = false;
    int count = 0;
    public Sprite Chill;
    public Sprite Evil;

    // Update is called once per frame
    void Update()
    {
        if (talking && Input.GetKeyDown(KeyCode.Space))
        {
            if (tweenerCore.IsPlaying())
            {
                tweenerCore.Complete();
            }
            else
            {
                printLog(comunities[count].name, comunities[count].dialogue);
            }
        }
    }

    public void printLog(string name, string dialogue)
    {
        if (dialogue == "")
        {
            talking = false;
            count = 0;
            panel.SetActive(false);
            image.gameObject.SetActive(false);
            return;
        }
        Name.text = "";
        Log.text = "";
        if (name == "Chill Guy") image.sprite = Chill;
        else if (name == "Evil Guy") image.sprite = Evil;
        talking = true;
        panel.SetActive(true);
        image.gameObject.SetActive(true);
        Name.text = name;
        tweenerCore = Log.DOText(dialogue, 1f);
        count++;
    }
}

[System.Serializable]
public class Comunity
{
    public string name;
    public string dialogue;

    public Comunity(string name, string dialogue)
    {
        this.name = name;
        this.dialogue = dialogue;
    }
}
