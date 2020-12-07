using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescreen : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject ResumeButton;

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
        ToggleButtons(IsPaused);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        ToggleButtons(IsPaused);
    }

    public void Menu()
    {
        // TODO: Create Constants
        // Time.timeScale = 1f;
        // IsPaused = false;
        Resume();
        BetweenLevel.IsBetweenLevels = false;
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(0);
        Debug.Log("Went to Menu!");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void ToggleButtons(bool paused)
    {
        PauseButton.SetActive(!paused);
        ResumeButton.SetActive(paused);
    }
}
