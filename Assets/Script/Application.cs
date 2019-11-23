using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all elements in this application
public class Element : MonoBehaviour
{
    // Gives access to the application and all instances
    public Application app { get { return GameObject.FindObjectOfType<Application>(); }}
}

// Application Entry Point
public class Application : MonoBehaviour
{
    // Reference to the root instances of the MVC
    public GameModel model;
    public GameView view;
    // public GameController controller;

    void Start() {}
}
