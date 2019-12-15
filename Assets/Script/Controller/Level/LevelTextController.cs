using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using amvcc;

public class LevelTextController : Controller<Application>
{
    public void SetText()
    {
        Text lvlText = app.model.lvltext.levelTextObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        lvlText.text = app.model.lvltext.levelName;
    }

    public IEnumerator RemoveTextAfterTime()
    {
        yield return new WaitForSeconds(app.model.lvltext.time2Disappear);
         Destroy(app.model.lvltext.levelTextObj);
    }
}

