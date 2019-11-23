using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Element
{
    // public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start() { offset = transform.position - app.view.player.transform.position; }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    { transform.position = app.view.player.transform.position + offset; }
}
