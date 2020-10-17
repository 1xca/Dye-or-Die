using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 1f;
    public GameObject GameOverPanel;

    private Rigidbody2D rBody;
    private bool isJumping = false;
    private bool touchingFast = false;
    private float fastTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {
        float currentY = rBody.velocity.y;
        if (!GameManager.Instance.IsGameOver)
        {
            if (fastTime > 0)
            {
                rBody.velocity = new Vector2(Speed * 3, currentY);
                fastTime -= Time.deltaTime;
            }
            else
            {
                rBody.velocity = new Vector2(Speed, currentY);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckSpeed(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckJump(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = false;
    }


    private void CheckJump(Collision2D collision)
    {
        if (!isJumping && collision.gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            isJumping = true;
            rBody.AddForce(Vector2.up * 400);
        }
    }

    private void CheckSpeed(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.green)
        {
            fastTime = 0.7f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Win")
        {
            GameManager.Instance.GameOver();
            GameOverPanel.SetActive(true);
        }
        else
        {
            GameManager.Instance.GameOver();
            GameOverPanel.SetActive(true);
        }
    }
}
