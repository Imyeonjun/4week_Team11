using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI gameOverText;

    public void Start()
    {
        if (gameOverText == null)
        {
            Debug.LogError("gmaeOverText is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        if (highscoreText == null)
        {
            Debug.LogError("highscoreText is null");
            return;
        }

        gameOverText.gameObject.SetActive(false);
    }

    public void SetGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore(int highscore)
    {
        highscoreText.text = highscore.ToString();
    }
}