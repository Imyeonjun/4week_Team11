using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    UIManager uiManager;

    private int currentScore = 0;
    static public bool isGameOver = false;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        isGameOver = true;
        uiManager.SetGameOver();
    }

    public void ExitMiniGame()
    {
        SceneManager.LoadScene("MainScene");
        isGameOver = false;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }

    public void SaveHighScore()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore", 0); // ����� �ְ� ���� �ҷ�����

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore); // �ְ� ���� ����
            PlayerPrefs.Save(); // ��� ����

            uiManager.UpdateHighScore(currentScore);
        }
    }
}