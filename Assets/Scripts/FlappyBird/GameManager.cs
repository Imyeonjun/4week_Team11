using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    UIManager uiManager;

    private int currentScore = 0;
    static public bool isGameOver = false;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        uiManager.SetGameOver();
    }

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    public void ExitMiniGame()
    {
        SceneManager.LoadScene("MainScene");
        isGameOver = false ;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }
}