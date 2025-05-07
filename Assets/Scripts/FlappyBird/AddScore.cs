using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager �ν��Ͻ��� �������� �ʽ��ϴ�!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameManager == null) return;

        if (GameManager.isGameOver == false)
        {
            Angel player = other.GetComponent<Angel>();
            if (player != null)
                gameManager.AddScore(1);
        }
        else
        {
            gameManager.SaveHighScore();
        }
    }
}
