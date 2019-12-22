using UnityEngine;
using System.Collections;
using amvcc;

public class LevelTextModel : Model<Application>
{
    public float time2Disappear = 5;
    public GameObject levelTextObj;

    public string levelName = "Day";
    public int levelNumber = 0;
    public int defaultLevelNumber = 0;
}
