using UnityEngine;
using System.Collections;
using amvcc;

public class CameraController : Controller<Application>
{
    private Vector3 offset;

    public void init()
    {
        offset = app.view.mainCamera.transform.position - app.model.mainCamera.player.transform.position;
    }

    public void move()
    {
        app.view.mainCamera.transform.position = app.model.mainCamera.player.transform.position + offset;
    }
}
