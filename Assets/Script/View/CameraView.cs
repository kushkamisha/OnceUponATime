using UnityEngine;
using System.Collections;
using amvcc;

public class CameraView : View<Application>
{
    // Start is called before the first frame update
    void Start() { Notify("camera", "init"); }

    // LateUpdate is called after Update each frame
    void LateUpdate() { Notify("camera", "move"); }
}
