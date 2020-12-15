using UnityEngine;

public class ColorBevahior : MonoBehaviour
{
    public int GroundLayer = 8;
    public ParticleSystem SplashParticles;
    public AudioClip paint;
    private Renderer rend;
    private AudioSource audioPlayer;
    
    public Material[] colorMaterials;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

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
        Color activeColor = GameManager.Instance.GetActiveColor();
        Material activeMaterial = colorMaterials[(int)GameManager.Instance.GetActiveColorIndex()];
        rend.material = activeMaterial;
        rend.material.color = activeColor;
        
        // Particles
        ParticleSystem.MainModule ma = SplashParticles.main;
        ma.startColor = activeColor;
        Instantiate(SplashParticles, collider.transform.position + new Vector3(1f,0.75f,-1.5f), Quaternion.identity);

        //Sound 
        audioPlayer.PlayOneShot(paint, 0.5f);
    }
}