using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null; 

    public bool IsGameOver = false;

    private int activeColorIndex = (int)Colors.Red;
    private Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };

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

    public void SetActiveColor(Colors color)
    {
        activeColorIndex = (int)color;
    }

    public Color GetActiveColor()
    {
        return colors[activeColorIndex];
    }
}

