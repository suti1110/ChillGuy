using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("BGM").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FadeInOut.SceneChange("FourthFloor");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FadeInOut.SceneChange("FifthFloor");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            FadeInOut.SceneChange("SixthFloor");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            FadeInOut.SceneChange("BossScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            GameObject dialogue = GameObject.Find("Dialogue");
            if (dialogue != null) dialogue.GetComponent<BossEnd>().GameClear();
        }
    }
}
