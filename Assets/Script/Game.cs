using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Game : MonoBehaviour
{
    public KeyCode newGameKey = KeyCode.N;
    public KeyCode saveKey    = KeyCode.S;

    public Sprite prefab;

    string savePath;
    List<GameObject> objects;

    void Start () {
       /* GameObject hero = GameObject.Instantiate(GameObject.Find(prefab.texture.ToString())) as GameObject;*/
        
        CreateObject();
    }

    void Update()
    {
        
        if (Input.GetKey(newGameKey))
        {
            BeginNewGame();
        }
        else if (Input.GetKeyDown(saveKey))
        {
            Save();
        }
    }
    void BeginNewGame() {
        for (int i = 0; i < objects.Count; i++){
            Destroy(objects[i]);
        }
        objects.Clear();

        CreateObject();
    }

    void CreateObject(){
        Debug.Log(prefab.texture);
        GameObject t = Instantiate(GameObject.Find(prefab.texture.ToString()));
        objects.Add(t);
    }

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    void Save(){
        using (
            var writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
        )
        {
            writer.Write(objects.Count);
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject s = objects[i];
                /*writer.Write(s.);
                writer.Write(s.bounds.center.y);
                writer.Write(s.bounds.center.z);*/
            }
        }
    }
}
