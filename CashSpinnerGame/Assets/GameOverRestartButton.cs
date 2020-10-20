using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRestartButton : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject RestartButton;
     void Start()
     {
           
        
    }

    void OnMouseDown()
    {
       Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Spinner");
       SceneManager.SetActiveScene(SceneManager.GetSceneByName("Spinner"));
    }
}
