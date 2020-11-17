using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null; 

    public bool IsGameOver = false;

    private int activeColorIndex = 3;
    private Color[] colors = new Color[] { Color.yellow, Color.red, Color.green, Color.blue };


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

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchColor();
        }

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    /* 
        Private Actions
    */ 
    private void ResetGame()
    {
        IsGameOver = false;
    }

    private void SwitchColor()
    {
        activeColorIndex++;
        if (activeColorIndex >= 4)
        {
            activeColorIndex = 0;
        }

        Debug.Log("Active Color is: " + GetActiveColor());
    }


    /* 
        Public Actions
    */ 
    public void GameOver()
    {
        IsGameOver = true;

        Debug.Log("Game Over!");
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

    public Color GetActiveColor()
    {
        return colors[activeColorIndex];
    }
}

