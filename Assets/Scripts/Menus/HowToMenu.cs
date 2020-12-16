using UnityEngine;
using UnityEngine.UI;

public class HowToMenu : MonoBehaviour
{

    public Sprite[] howToScreens;
    public GameObject leftButton;
    public GameObject rightButton;

    private Pages currentPage;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if(currentPage == Pages.Tip)
        {
            rightButton.SetActive(false);
        }
        else 
        {
            rightButton.SetActive(true);
        }
        if(currentPage == Pages.Goal)
        {
            leftButton.SetActive(false);
        }
        else 
        {
            leftButton.SetActive(true);
        }
    }

    public void nextPage()
    {
        if(currentPage != Pages.Tip)
        {
            currentPage += 1;
            image.sprite = howToScreens[(int)currentPage];
        }
    }

    public void previousPage()
    {
        if(currentPage != Pages.Goal)
        {
            currentPage -= 1;
            image.sprite = howToScreens[(int)currentPage];
        }
    }
}

public enum Pages {
    Goal,
    Control,
    Colorize,
    Colors,
    Tip
}