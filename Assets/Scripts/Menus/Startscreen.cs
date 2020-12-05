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
    private bool selection;

    public void SelectButton(GameObject obj)
    {
        TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();
        text.font = boldFont;
        // obj.transform.position += Vector3.right * highlightOffset;

    }

    public void DeselectButton(GameObject obj)
    {
        TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();
        text.font = lightFont;
        // obj.transform.position += Vector3.left * highlightOffset;
    }

    public void ToogleSelectLevelsButton()
    {
        selection = !selection;
        levelsAnimator.SetBool("Selected", selection);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}