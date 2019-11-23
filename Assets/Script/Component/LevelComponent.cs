using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameTags;

public class LevelComponent : MonoBehaviour
{
    public string scenesDir = "Scenes/";
    public string sceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTags.player))
            SceneManager.LoadScene(scenesDir + sceneName);
    }
}
