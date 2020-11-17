using UnityEngine.SceneManagement;
using UnityEngine;

public class Startscreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}