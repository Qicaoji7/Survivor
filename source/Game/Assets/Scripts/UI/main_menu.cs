using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public GameObject setting;
    public void StartGame()
    {
        load_scene.targetScene = "MainGame";
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1.0f;
    }

    public void Tutorial()
    {
        load_scene.targetScene = "Tutorial";
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1.0f;
    }

    public void Setting()
    {
        if(setting.activeSelf == false)
        {
            setting.SetActive(true);
        }
    }

    public void SettingBack()
    {
        if (setting.activeSelf)
        {
            setting.SetActive(false);
        }
    }

    public void QuitGame()
    {
        /*if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {*/
            Application.Quit();
        //}
    }


}
