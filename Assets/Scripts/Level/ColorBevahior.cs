using UnityEngine;

public class ColorBevahior : MonoBehaviour
{
    public int GroundLayer = 8;
    public ParticleSystem SplashParticles;
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
        Color active = GameManager.Instance.GetActiveColor();
        rend.material.color = active;
        ParticleSystem.MainModule ma = SplashParticles.main;
        ma.startColor = active;
        Instantiate(SplashParticles, collider.transform.position + new Vector3(1f,0.75f,-1.5f), Quaternion.identity);
    }
}