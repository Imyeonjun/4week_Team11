using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    [HideInInspector]
    public string miniGameScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CanEnterMiniGame())
            {
                EnterMiniGame();
            }
        }
    }

    private bool CanEnterMiniGame()
    {
        return true;
    }

    private void EnterMiniGame()
    {
        if (string.IsNullOrEmpty(miniGameScene))
        {
            Debug.LogWarning("�̴ϰ��� ���� �������� �ʾҽ��ϴ�.");
            return;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(miniGameScene);
    }
}
