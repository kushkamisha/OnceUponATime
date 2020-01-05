using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame() { UnityEngine.Application.Quit(); }
}
