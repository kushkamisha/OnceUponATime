﻿using UnityEngine;
using System.Collections;
using amvcc;

public class LevelView : View<Application>
{
    void Start() { Notify ("level", "init"); }
    void OnTriggerEnter2D(Collider2D col) { Notify("level door", col); }
}
