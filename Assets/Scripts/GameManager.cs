using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null; 

    public bool IsGameOver = false;
    public AudioSource audioPlayer;
    public AudioClip win;
    public AudioClip lose;
    public Texture2D cursorTexture;

    private int extraCharacters = 0;
    private int activeColorIndex = (int)Colors.Jump;
    private Color[] colors = new Color[] { Color.yellow, Color.red, Color.blue, Color.magenta, Color.white };

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } 
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.PageUp))
        {
            NextLevel();
        } 
        else if(Input.GetKeyDown(KeyCode.PageDown)) 
        {
            PreviousLevel();
        }
        if(IsGameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ResetGame();
            }
        }
    }

    /* 
        Private Actions
    */ 
    public void ResetGame()
    {
        IsGameOver = false;
        GameObject.FindGameObjectWithTag("UI").transform.GetChild(3).gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /* 
        Public Actions
    */ 
    public void GameOver(int alive)
    {
        extraCharacters = alive;
        if(alive <= 0)
        {
            IsGameOver = true;
            audioPlayer.PlayOneShot(lose);
        } else 
        {
            audioPlayer.PlayOneShot(win);
        }
        BetweenLevel.IsBetweenLevels = true;
    }

    public void NextLevel() 
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

        Debug.Log("Loading Scene: " + nextSceneIndex);
    }

    public void PreviousLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(nextSceneIndex);

        Debug.Log("Loading Scene: " + nextSceneIndex);
    }

    public void SetActiveColor(Colors color)
    {
        activeColorIndex = (int)color;
    }

    public Color GetActiveColor()
    {
        return colors[activeColorIndex];
    }

    public Colors GetActiveColorIndex()
    {
        return (Colors)activeColorIndex;
    }

    public int GetExtraCharacters()
    {
        return extraCharacters;
    }
}

