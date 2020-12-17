using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System.Collections;

public class Startscreen : MonoBehaviour
{
    public TMP_FontAsset lightFont;
    public TMP_FontAsset boldFont;
    public float highlightOffset = 20f;
    public Animator levelsAnimator;
    public Animator howToAnimator;
    
    public VideoPlayer videoPlayer;
    public GameObject videoObject;
    public AudioClip selectMenuItem;
    private AudioSource audioPlayer;
    private bool quickStartVideoPlaying = false;

    void Start()
    {
        audioPlayer = GameManager.Instance.GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            MusicPlayer.Instance.RefreshButtonText();
        }
    }

    void Update()
    {
        if(quickStartVideoPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StopVideoAndStartLevel();
            }
        }
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

    public void ToogleSelectLevelsButton(bool selection)
    {
        levelsAnimator.SetBool("Selected", selection);
    }
    public void ToogleHowToButton(bool selection)
    {
        howToAnimator.SetBool("Selected", selection);
    }

    public void LoadLevel(int index)
    {
        audioPlayer.PlayOneShot(selectMenuItem, 0.7f);
        SceneManager.LoadScene(index);
    }

    public void QuickStart()
    {
        videoPlayer.time = 0f;
        videoPlayer.Play();
        quickStartVideoPlaying = true;
        StartCoroutine(StartLevelAfter());
    }
     
    IEnumerator StartLevelAfter()
    {
        float delayTime = (float)videoPlayer.length;
        yield return new WaitForSeconds(delayTime + 0.5f);
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StopVideoAndStartLevel(){
        StopCoroutine("StartLevelAfter");
        //videoObject.SetActive(false);
        quickStartVideoPlaying = false;
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void PlayAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(0);
    }

    public void ToggleMusic()
    {
        MusicPlayer.Instance.Toggle();
    }

    public void PlayButtonSelectSound() 
    {
        audioPlayer.PlayOneShot(selectMenuItem, 0.7f);
    }
}