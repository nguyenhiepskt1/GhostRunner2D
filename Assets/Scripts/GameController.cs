using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float spawnTime;
    public GameObject obstacle;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    UIManager m_ui;

    void Start()
    {
        spawnTime = 3;
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_score = 0;
        m_ui.SetTextScore("Score: " + m_score);
    }
  
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if(m_isGameOver)
        {
            spawnTime = 0;
            m_ui.showPanelGameOver(true);
            Time.timeScale = 0;
            return;
        }
        
        if(m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }

        if(m_score >= 50)
        {
            spawnTime = 2;
        }
    }

    public void SpawnObstacle()
    {
        Vector2 spawnPos = new Vector2(Random.Range(8.8f, 12f), Random.Range(-1.87f, -4));

        if(obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    public void PlayAgain()
    {
        m_score = 0;
        spawnTime = 3;
        m_ui.SetTextScore("Score: " + m_score);
        m_isGameOver = false;
        m_ui.showPanelGameOver(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }

    public void IncrementScore()
    {
        m_score++;
        m_ui.SetTextScore("Score: " + m_score);
    }

    public bool IsGameOver()
    {
        return m_isGameOver;
    }

    public void SetStateGameOver(bool state)
    {
        m_isGameOver = state;
    }
}
