using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial_controller : MonoBehaviour
{
    public static tutorial_controller instance;
    public GameObject firstTuto;
    public GameObject secondTuto;

    private void Awake()
    {
        instance = this;
    }

    public void ToMainMenu()
    {
        load_scene.targetScene = "MainMenu";
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1.0f;
    }
    public void ToMainGame()
    {
        load_scene.targetScene = "MainGame";
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1.0f;
    }

    public void ShowFirstTuto()
    {
        firstTuto.gameObject.SetActive(true);
        secondTuto.gameObject.SetActive(false);
    }

    public void ShowSecondTuto()
    {
        secondTuto.gameObject.SetActive(true);
        firstTuto.gameObject.SetActive(false);
    }
}
