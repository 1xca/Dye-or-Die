﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescreen : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Colorpicking.IsSlowedDown)
            {
                if(IsPaused){
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume() 
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Menu()
    {
        // TODO: Create Constants
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Debug.Log("Went to Menu!");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}