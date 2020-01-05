using UnityEngine;
using System.Collections;
using amvcc;

public class PauseView : View<Application>
{
    public void PauseGame() { Notify("game", "pause"); } 

    public void ResumeGame() { Notify("game", "resume"); } 
}
