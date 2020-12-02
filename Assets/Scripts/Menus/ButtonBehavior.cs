using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    private RectTransform button;

    public void Start()
    {
        button = this.GetComponent<RectTransform>();
    }
    public void Scale(float scale)
    {
        button.localScale = new Vector3(scale, scale, 1f);
    }   
}
