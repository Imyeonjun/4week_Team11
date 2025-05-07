using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Angel player = other.GetComponent<Angel>();
        if (player != null)
            gameManager.AddScore(1);
    }
}
