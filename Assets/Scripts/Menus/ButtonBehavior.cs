using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    private Image buttonImage;
    public Sprite activeTexture;
    public Sprite inactiveTexture;

    public void Start()
    {
        buttonImage = this.GetComponent<Image>();
    }
    public void Activate()
    {
        buttonImage.sprite = activeTexture;
    }   

    public void Deactivate()
    {
        buttonImage.sprite = inactiveTexture;
    }

    public void OnDisable()
    {
        Deactivate();
    }
}
