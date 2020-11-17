using UnityEngine;

// TODO: Rework
public class CharacterMovement : MonoBehaviour
{
    public float Speed = 5f; 

    private bool isGrounded = true;
    private float speedyTime = 0f;
    private bool reverseGravity = false;

    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(speedyTime > 0) 
        {
            speedyTime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rBody.AddForce(new Vector3(Speed, 0, 0));
        float newVelocityX = Mathf.Clamp(rBody.velocity.x, 0f, 3f); 
        if(speedyTime <= 0f)
        {
            rBody.velocity = new Vector3(newVelocityX, rBody.velocity.y, 0);
        }
        if(reverseGravity) {
            rBody.AddForce(Vector3.up * 9.81f);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.layer == 8) //floor is 8
        {
         isGrounded = true;
        }

        // Jump
        Renderer rend = other.gameObject.GetComponent<Renderer>();
        if(isGrounded && rend.material.color == Color.yellow) 
        {
            rBody.AddForce(Vector3.up * 500f);
            print("Debug Jump");
        }
        if(isGrounded && rend.material.color == Color.red) 
        {
            speedyTime = 1f;
            print("Debug Jump");
        }
        if(rend.material.color == Color.blue) 
        {
            //Physics.gravity = -Physics.gravity;
            rBody.useGravity = !rBody.useGravity;
            reverseGravity = !reverseGravity;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.layer == 8) //floor is 8
        {
            isGrounded = false;
        }
    }   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Win")
        {
            //GameManager.Instance.GameOver();
        }
        if(other.gameObject.name == "Death")
        {
            //GameManager.Instance.GameOver();
        }
    }
}
