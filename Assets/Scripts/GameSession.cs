using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    int highestScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highestScoreText;



    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void SaveHighestScore()
    {
        if (score > highestScore)
        {
            highestScore = score;

            highestScoreText.text = highestScore.ToString();
        }

        score = 0;
        scoreText.text = score.ToString();
    }


    internal void ResetGameSession()
    {
        SaveHighestScore();
        SceneManager.LoadScene(0);
    }
}
