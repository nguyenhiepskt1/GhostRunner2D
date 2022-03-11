using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float moveSpeed;

    GameController m_gc;

    private void Start()
    {
        moveSpeed = 5;
        m_gc = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        if (m_gc.IsGameOver())
        {
            Destroy(gameObject);
        }

        if(m_gc.GetScore() >= 50)
        {
            moveSpeed = 9;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            m_gc.SetStateGameOver(true);
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SceneLimit"))
        {
            m_gc.IncrementScore();
            Destroy(gameObject);
        }
    }

}
