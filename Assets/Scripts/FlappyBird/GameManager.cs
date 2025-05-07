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

    static public bool isGameOver = false;

    int currentScore = 0;

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
        int bestScore = PlayerPrefs.GetInt("HighScore", 0); // 저장된 최고 점수 불러오기

        currentScore += score;
        Debug.Log($"현재 점수: {currentScore} / 최고 점수: {bestScore}");

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore); // 최고 점수 갱신
            PlayerPrefs.Save(); // 즉시 저장

            uiManager.UpdateHighScore(currentScore);
        }
        else
        {
            Debug.Log("현재 점수가 최고 점수보다 낮습니다.");
        }

        uiManager.UpdateScore(currentScore);
    }
}