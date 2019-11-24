using UnityEngine;
using System.Collections;
using thelab.mvc;

public class PlayerModel : Model<Application>
{
    public float playerMoveSpeed = 5f;
    public int bounces;
}
