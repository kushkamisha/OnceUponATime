using UnityEngine;
using System.Collections;
using amvcc;

public class LvlGenView : View<Application>
{
    void Start() { Notify("level", "generate"); }
}
