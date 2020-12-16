using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance = null; 
    private TextMeshProUGUI musikButton;
    private AudioSource audioPlayer;
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

    public void Toggle()
    {
        audioPlayer = GetComponent<AudioSource>();
        
        if(audioPlayer.isPlaying)
        {
            audioPlayer.Pause();
        }
        else 
        {
            audioPlayer.UnPause();
        }
        RefreshButtonText();
    }

    public void RefreshButtonText()
    {
        musikButton = GameObject.FindGameObjectWithTag("MusicButton").GetComponent<TextMeshProUGUI>();
        audioPlayer = GetComponent<AudioSource>();
        if(audioPlayer.isPlaying)
        {
            musikButton.text = "MUSIC: ON";
        }
        else
        {
            musikButton.text = "MUSIC: OFF";
        }
    }
}
