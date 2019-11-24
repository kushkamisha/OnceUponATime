using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using amvcc;

public class LevelController : Controller<Application>
{
    public void loadScene(Collider2D col)
    {
        if (col.CompareTag(GameTags.player))
            SceneManager.LoadScene(app.model.level.scenesDir + app.model.level.sceneName);
    }
}
