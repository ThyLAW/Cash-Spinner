 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class RestartButtonScript : MonoBehaviour{
     
        [Header("Set in Inspector")]
        public GameObject RestartButton;
     void Start()
     {
        
    }

    void OnMouseDown()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
 }
 
