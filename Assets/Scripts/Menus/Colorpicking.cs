﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Colorpicking : MonoBehaviour
{
    public GameObject ColorPickerUI;
    public Button[] ColorButtons;
    public static bool IsSlowedDown = false;
    public AudioClip pickSound;
    private Colors activeColor = Colors.none; 
    private AudioSource audioPlayer;

    void Start()
    {
        // ColorButtons[(int)Colors.Red].GetComponent<Image>().color = Color.red;
        // ColorButtons[(int)Colors.Blue].GetComponent<Image>().color = Color.blue;
        // ColorButtons[(int)Colors.Green].GetComponent<Image>().color = Color.green;
        // ColorButtons[(int)Colors.Yellow].GetComponent<Image>().color = Color.yellow;
        // ColorButtons[(int)Colors.none].GetComponent<Image>().color = Color.white;
        GameManager.Instance.SetActiveColor(activeColor);
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!Pausescreen.IsPaused && !BetweenLevel.IsBetweenLevels)
        {
            if(Input.GetMouseButtonDown(1) && !IsSlowedDown)
            {
                SlowDown();
                Cursor.lockState = CursorLockMode.Locked;
                StartCoroutine(UnlockMouse());  
            }
            if(IsSlowedDown)
            {
                // Revert when menu is active and mouse is lifted
                if(Input.GetMouseButtonUp(1))
                {
                    SpeedUp();
                }
            }
        }
    }

    IEnumerator UnlockMouse()
    {
        yield return 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SlowDown()
    {
        ColorPickerUI.SetActive(true);
        Time.timeScale = 0.25f;
        IsSlowedDown = true;

        ColorButtons[(int)activeColor].Select();
    }

    public void SpeedUp()
    {
        ColorPickerUI.SetActive(false);
        Time.timeScale = 1f;
        IsSlowedDown = false;
    }

    public void PickColor(int color)
    {
        activeColor = (Colors)color;
        GameManager.Instance.SetActiveColor(activeColor);
        audioPlayer.PlayOneShot(pickSound);
        // SpeedUp();
    }
}

public enum Colors
{
    Jump,
    Fast,
    Gravity,
    Direction,
    none
}
