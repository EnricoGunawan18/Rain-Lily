using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;

        if(scene == "Novel" )
        {
            SceneManager.MoveGameObjectToScene(GameObject.Find("Novel"), SceneManager.GetSceneByName("Novel"));
        }
    }
}
