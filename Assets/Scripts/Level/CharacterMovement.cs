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
    private GameObject alreadyReactedOn = null;
    private float reactionTimer = 0f;
    private bool needsGravity = true;

    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.useGravity = !rBody.useGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if(speedyTime > 0) 
        {
            speedyTime -= Time.deltaTime;
        }
        if(reactionTimer > 0)
        {
            reactionTimer -= Time.deltaTime;
        }
        else 
        {
            alreadyReactedOn = null;
        }
    }

    private void FixedUpdate()
    {
        rBody.AddForce(new Vector3((!directionReversed ? 1 : -1) * Speed, 0, 0));
        if(needsGravity)
        {
            
            rBody.AddForce((gravityReversed ? Vector3.up : Vector3.down) * 20f * rBody.mass);
        }
        float newVelocityX;
        
        if(speedyTime <= 0f)
        {
            newVelocityX = Mathf.Clamp(rBody.velocity.x, -2f, 2f);
            rBody.velocity = new Vector3(newVelocityX, rBody.velocity.y, 0);
        }
        else
        {
            newVelocityX = Mathf.Clamp(rBody.velocity.x, -3f, 3f);
            rBody.velocity = new Vector3(newVelocityX, rBody.velocity.y, 0);
        }

        // if(rBody.velocity.magnitude >= 30)
        // {
        //     needsGravity = false;
        // } 
        // else
        // {
        //     needsGravity = true;
        // }

        
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.layer == 8) //floor is 8
        {
         isGrounded = true;
        }

        // Jump
        Renderer rend = other.gameObject.GetComponent<Renderer>();
        if(!(other.gameObject.Equals(alreadyReactedOn)) && reactionTimer <= 0)
        {
            alreadyReactedOn = other.gameObject;
            if(!invoking)
            {
                if(isGrounded && rend.material.color == Color.yellow) 
                {
                    Invoke("Jump", 0.5f);
                    invoking = true;
                    reactionTimer = 0.75f;
                }
                if(isGrounded && rend.material.color == Color.red) 
                {
                    Invoke("IncreaseSpeed", 0.5f);
                    invoking = true;
                    reactionTimer = 0.75f;
                }
                if(rend.material.color == Color.blue) 
                {
                    Invoke("ReverseGravity", 0.5f);
                    invoking = true;
                    reactionTimer = 0.75f;
                }
                if(rend.material.color == Color.green)
                {
                    Invoke("ReverseDirection", 0f);
                    invoking = true;
                    reactionTimer = 0.75f;
                }
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
            Debug.Log("Win with: " + this.name);
            gameObject.SetActive(false);
            CharacterManager.Instance.LoseCharacter(true);
        }
        if(other.gameObject.CompareTag("LoseCondition"))
        {
            Debug.Log("Lost: " + this.name);
            Destroy(gameObject);
            CharacterManager.Instance.LoseCharacter(false);
        }
    }

    private void Jump()
    {
        rBody.AddForce((!gravityReversed ? Vector3.up : Vector3.down) * 30000f);
        invoking = false;
    }


    private void IncreaseSpeed()
    {
        speedyTime = 2f;
        invoking = false;
    }

    private void ReverseGravity()
    {
        gravityReversed = !gravityReversed;
        invoking = false;
    }

    private void ReverseDirection()
    {
        directionReversed = !directionReversed;
        invoking = false;
    }
}
