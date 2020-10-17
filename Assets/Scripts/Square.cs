using System;
using UnityEditor.UI;
using UnityEngine;

public class Square : MonoBehaviour
{

    private SpriteRenderer renderer; 
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateColor();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.transform.name == this.name)
                {
                    Debug.Log("Something was clicked!");
                    renderer.color = GameManager.Instance.ActiveColor;
                }
            }
        }
    }
}
