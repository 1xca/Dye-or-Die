using UnityEngine;

// TODO: Rework
public class CharacterMovement : MonoBehaviour
{
    public float Speed = 100f; 

    private bool isGrounded = true;
    private float speedyTime = 0f;
    private bool gravityReversed = false;
    private bool directionReversed = false;
    private bool invoking = false;

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
        rBody.AddForce(new Vector3((!directionReversed ? 1 : -1) * Speed, 0, 0));
         float newVelocityX;
        if(speedyTime <= 0f)
        {
            newVelocityX = Mathf.Clamp(rBody.velocity.x, -1f, 1f);
            rBody.velocity = new Vector3(newVelocityX, rBody.velocity.y, 0);
        }
        else
        {
            newVelocityX = Mathf.Clamp(rBody.velocity.x, -3f, 3f);
            rBody.velocity = new Vector3(newVelocityX, rBody.velocity.y, 0);
        }
        if(gravityReversed) {
            rBody.AddForce(Vector3.up * 20f);
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
        if(!invoking)
        {
            if(isGrounded && rend.material.color == Color.yellow) 
            {
                Invoke("Jump", 0.5f);
                invoking = true;
            }
            if(isGrounded && rend.material.color == Color.red) 
            {
                Invoke("IncreaseSpeed", 0.5f);
                invoking = true;
            }
            if(rend.material.color == Color.blue) 
            {
                Invoke("ReverseGravity", 0.5f);
                invoking = true;
            }
            if(rend.material.color == Color.green)
            {
               Invoke("ReverseDirection", 0.3f);
                invoking = true;
            }
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
            Debug.Log("Win with: " + this.name);
            gameObject.SetActive(false);
        }
        if(other.gameObject.name == "Lose")
        {
            //GameManager.Instance.GameOver();
            Debug.Log("Lost: " + this.name);
            gameObject.SetActive(false);
        }
    }

    private void Jump()
    {
        rBody.AddForce((!gravityReversed ? Vector3.up : Vector3.down) * 600f);
        invoking = false;
    }


    private void IncreaseSpeed()
    {
        speedyTime = 2f;
        invoking = false;
    }

    private void ReverseGravity()
    {
        rBody.useGravity = !rBody.useGravity;
        gravityReversed = !gravityReversed;
        invoking = false;
    }

    private void ReverseDirection()
    {
        directionReversed = !directionReversed;
        invoking = false;
    }
}
