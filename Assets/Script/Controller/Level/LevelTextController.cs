using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using amvcc;

public class LevelTextController : Controller<Application>
{
    private Text lvlText;

    void Update()
    {
        // Total shit! Must be replaced more smart!
        // if (app.controller.player.getCreature().hp < 0)
        // {
            // gameOver();
        // }
    }

    public void SetText()
    {
        lvlText = app.model.lvltext.levelTextObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        lvlText.text = app.model.lvltext.levelName + " " + app.model.lvltext.levelNumber.ToString();
    }

    public IEnumerator RemoveTextAfterTime()
    {
        yield return new WaitForSeconds(app.model.lvltext.time2Disappear);
        // Destroy(app.model.lvltext.levelTextObj);
        lvlText = app.model.lvltext.levelTextObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        lvlText.text = "";
    }
}

