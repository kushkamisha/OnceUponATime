using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlChanger : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("collider");
        if (col.CompareTag("Player")) {
            Debug.Log("collider with Player");
            SceneManager.LoadScene("Scenes/" + sceneName);
        }
    }
}
