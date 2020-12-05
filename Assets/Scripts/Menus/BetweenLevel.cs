using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BetweenLevel : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI levelIndexText;
    public TextMeshProUGUI savedBallsText;
    public TextMeshProUGUI nextText;
    public TextMeshProUGUI headerText;

    public static bool IsBetweenLevels = false;

    void Update()
    {
        SetScreenActive(IsBetweenLevels);
    }

    public void SetScreenActive(bool active)
    {
        gameOverScreen.SetActive(active);

        int savedBalls = GameManager.Instance.GetExtraCharacters();
        if(savedBalls > 0)
        {
            nextText.text = "NEXT LEVEL";
            headerText.text = "YOU DYED!";
        }
        else 
        {
            nextText.text = "TRY AGAIN";
            headerText.text = "YOU DIED!";
        }
        
        savedBallsText.text = savedBalls.ToString();
        levelIndexText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    public void LoadNextLevel()
    {
        int savedBalls = GameManager.Instance.GetExtraCharacters();
        if(savedBalls > 0)
        {
            GameManager.Instance.NextLevel();
        }
        else 
        {
            GameManager.Instance.ResetGame();
        }
        IsBetweenLevels = false;
    }
}
