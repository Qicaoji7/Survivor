using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_level_manager : MonoBehaviour
{
    public static game_level_manager Instance;
    private bool gameActive;
    private float timer;

    public float levelTimer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameActive = true;
    }

    private void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            if(timer >= levelTimer)
            {
                EndLevel();
            }
            UI_controller.Instance.UpdateTimer(timer);
        }
    }

    public void EndLevel()
    {
        gameActive = false;
        Time.timeScale = 0.0f;
        UI_controller.Instance.gameOversPanel.SetActive(true);
    }
    
}
