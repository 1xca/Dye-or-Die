using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Startscreen : MonoBehaviour
{
    public TMP_FontAsset lightFont;
    public TMP_FontAsset boldFont;
    public float highlightOffset = 20f;
    public Animator levelsAnimator;
    public Animator howToAnimator;
    
    public AudioClip selectMenuItem;
    private AudioSource audioPlayer;

    void Start()
    {
        audioPlayer = GameManager.Instance.GetComponent<AudioSource>();
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
        audioPlayer.PlayOneShot(selectMenuItem);
        SceneManager.LoadScene(index);
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
}