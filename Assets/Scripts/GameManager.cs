using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null; 

    public bool IsGameOver = false;

    public Color ActiveColor;

    private int activeColorIndex;
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

    // Start is called before the first frame update
    void Start()
    {
        activeColorIndex = 0;
        ActiveColor = colors[activeColorIndex];
    }

    private void ResetGame()
    {
        IsGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && IsGameOver)
        {
            ResetGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            activeColorIndex++;
            if (activeColorIndex >= 4)
            {
                activeColorIndex = 0;
            }
            ActiveColor = colors[activeColorIndex];
            Debug.Log("Color is" + ActiveColor.ToString());
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
    }
}
