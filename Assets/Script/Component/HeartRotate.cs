using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotate : MonoBehaviour
{
    float y_speed = 5.0f;
    void Update()
    {
        transform.Rotate(0, y_speed, 0);
    }
}
