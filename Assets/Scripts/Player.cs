using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float jumpForce;
    float downForce;
    Rigidbody2D m_rb;

    bool m_isGround;

    public AudioSource audio;
    public AudioClip jumpSound;

    GameController m_gc;

    void Start()
    {
        jumpForce = 440;
        downForce = 700;
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }
   
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        bool isUpKeyPressed = Input.GetKeyDown(KeyCode.UpArrow);
        bool isDownKeyPressed = Input.GetKeyDown(KeyCode.DownArrow);

        if (isJumpKeyPressed && m_isGround || isUpKeyPressed && m_isGround && audio)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;

            audio.PlayOneShot(jumpSound);
        }

        if(isDownKeyPressed && !m_isGround)
        {
            m_rb.AddForce(Vector2.down * downForce);
            m_isGround = true;
        }  
        
        if(audio && m_gc.IsGameOver())
        {
            audio.Pause();
        }
        else
        {
            audio.UnPause();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    public void JumpButton()
    {
        if(!m_isGround)
        {
            return;
        }

        m_rb.AddForce(Vector2.up * jumpForce);
        m_isGround = false;

        audio.PlayOneShot(jumpSound);
    }

    public void DownButton()
    {
        if(m_isGround)
        {
            return;
        }

        m_rb.AddForce(Vector2.down * downForce);
        m_isGround = true;
    }
}
