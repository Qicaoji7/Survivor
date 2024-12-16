using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    private string targetScene = "MainGame";


    public void SetScene(string sceneName)
    {
        if (targetScene != sceneName)
        {
            load_scene.targetScene = targetScene = sceneName;
            SceneManager.LoadScene("Loading");
        }
    }
}
