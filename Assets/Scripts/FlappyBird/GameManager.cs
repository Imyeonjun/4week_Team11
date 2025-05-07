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
        int bestScore = PlayerPrefs.GetInt("HighScore", 0); // ����� �ְ� ���� �ҷ�����

        currentScore += score;
        Debug.Log($"���� ����: {currentScore} / �ְ� ����: {bestScore}");

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore); // �ְ� ���� ����
            PlayerPrefs.Save(); // ��� ����

            uiManager.UpdateHighScore(currentScore);
        }
        else
        {
            Debug.Log("���� ������ �ְ� �������� �����ϴ�.");
        }

        uiManager.UpdateScore(currentScore);
    }
}