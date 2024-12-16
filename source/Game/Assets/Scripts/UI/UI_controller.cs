using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{
    public static UI_controller Instance;
    public Slider levelSlider;
    public TMP_Text levelText;
    public TMP_Text timeText;
    public List<level_up_selection_button> levelUpButtons = new List<level_up_selection_button>();
    public GameObject levelUpBonusPanel;
    public GameObject gameOversPanel;
    public GameObject gamePausePanel;
    public string mainMenuName;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        levelSlider.value = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void UpdateExp(int currentExp, int previousExp, int levelExp, int currentLevel)
    {
        levelSlider.maxValue = levelExp;
        levelSlider.minValue = previousExp;
        levelSlider.value = currentExp;
        levelText.text = "Level" + (currentLevel + 1);
    }

    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60f);

        timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void Restart()
    {
        load_scene.targetScene = "MainGame";
        SceneManager.LoadScene("Loading");;
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
            Application.Quit();
    }

    public void OpenMainMenu()
    {
        load_scene.targetScene = mainMenuName;
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        if (gamePausePanel.activeSelf)
        {
            gamePausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            gamePausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOversPanel.SetActive(true);
    }
}
