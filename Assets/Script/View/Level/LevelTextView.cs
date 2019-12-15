using UnityEngine;
using System.Collections;
using amvcc;

public class LevelTextView : View<Application>
{
    void Start() { Notify("level.text", "wait"); }
}

