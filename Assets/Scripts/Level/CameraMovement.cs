using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Camera;
    public float ScrollSpeed = 20f;
    public float MinX = -10.5f;
    public float MaxX = 55f;
    
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) && Camera.position.x > MinX)
        {
            Camera.position += Vector3.left * ScrollSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D) && Camera.position.x < MaxX)
        {
            Camera.position += Vector3.right * ScrollSpeed * Time.deltaTime;
        }
    }
}
