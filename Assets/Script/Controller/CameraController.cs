using UnityEngine;
using System.Collections;
using thelab.mvc;

public class CameraController : Controller<Application>
{
    public PlayerView player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start() { offset = transform.position - player.transform.position; }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    { transform.position = player.transform.position + offset; }
}
