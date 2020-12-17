using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HowToMenu : MonoBehaviour
{

    public Texture[] howToScreens;
    public GameObject leftButton;
    public GameObject rightButton;
    public VideoPlayer videoPlayer;

    private Pages currentPage = Pages.Goal;
    private RawImage image;

    void Start()
    {
        image = GetComponent<RawImage>();
        image.texture = howToScreens[(int)currentPage];
    }

    void Update()
    {
        if(currentPage == Pages.Video)
        {
            rightButton.SetActive(false);
            videoPlayer.Play();
        }
        else 
        {
            rightButton.SetActive(true);
            videoPlayer.Pause();
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
        if(currentPage != Pages.Video)
        {
            currentPage += 1;
            image.texture = howToScreens[(int)currentPage];
        }
    }

    public void previousPage()
    {
        if(currentPage != Pages.Goal)
        {
            currentPage -= 1;
            image.texture = howToScreens[(int)currentPage];
        }
    }
}

public enum Pages {
    Goal,
    Control,
    Colorize,
    Colors,
    Tip,
    Video
}