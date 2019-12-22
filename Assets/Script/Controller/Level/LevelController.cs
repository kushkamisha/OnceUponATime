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

    public void Init()
    {
        // Set the level number
        PlayerPrefs.SetInt("level.number", app.model.lvltext.levelNumber);

        // Set the number of enemies for the level
        PlayerPrefs.SetInt("enemies.number", app.model.lvlgen.defaultEnemyAmount);
    }

    // Pass data when a scene changes
    void OnDisable()
    {
        PlayerPrefs.SetInt("level.number", app.model.lvltext.levelNumber);
        PlayerPrefs.SetInt("enemies.number", app.model.lvlgen.enemyAmount);
    }

    // Load data for a new scene
    void OnEnable()
    {
        app.model.lvltext.levelNumber = PlayerPrefs.GetInt("level.number") + 1; // change the number of the level
        app.model.lvlgen.enemyAmount = PlayerPrefs.GetInt("enemies.number") + 1;
    }

    // Reset the level number to the default
    void OnApplicationQuit()
    {
        app.model.lvltext.levelNumber = app.model.lvltext.defaultLevelNumber;
        app.model.lvlgen.enemyAmount = app.model.lvlgen.defaultEnemyAmount;
    }
}
