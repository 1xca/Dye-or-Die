using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pausescreen : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject ResumeButton;

    public TMP_FontAsset lightFont;
    public TMP_FontAsset boldFont;
    public AudioClip selectMenuItem;

    private AudioSource audioPlayer;

    void Start()
    {
        audioPlayer = GameManager.Instance.GetComponent<AudioSource>();
    }

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
        audioPlayer.PlayOneShot(selectMenuItem);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        ToggleButtons(IsPaused);
        audioPlayer.PlayOneShot(selectMenuItem);
    }

    public void Menu()
    {
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

    public void SelectButton(GameObject obj)
    {
        TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();
        text.font = boldFont;

    }

    public void DeselectButton(GameObject obj)
    {
        TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();
        text.font = lightFont;
    }
}
