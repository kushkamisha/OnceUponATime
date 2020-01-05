using UnityEngine;
using System.Collections;
using amvcc;

public class PauseController : Controller<Application>
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        app.model.pause.pausePanel.SetActive(true);
        app.model.pause.pauseButton.SetActive(false);
    } 

    public void ResumeGame()
    {
        Time.timeScale = 1;
        app.model.pause.pausePanel.SetActive(false);
        app.model.pause.pauseButton.SetActive(true);
    }
}
