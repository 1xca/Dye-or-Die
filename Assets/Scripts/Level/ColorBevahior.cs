using UnityEngine;

public class ColorBevahior : MonoBehaviour
{
    public int GroundLayer = 8;
    private Renderer rend;

    void Update()
    {
        CheckMouse();
    }

    private void CheckMouse() 
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && !Colorpicking.IsSlowedDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Object: " + hit.collider.name + " has been clicked");

                // Only Paint if Object is actually Ground 
                if(hit.collider.gameObject.layer == GroundLayer)
                {
                    PaintObject(hit.collider);
                }
            }
        }
    }

    private void PaintObject(Collider collider)
    {
        rend = collider.gameObject.GetComponent<Renderer>();
        rend.material.color = GameManager.Instance.GetActiveColor();   
    }
}