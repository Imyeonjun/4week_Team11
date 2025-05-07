using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    public string miniGameSceneName = "FlappyBirdScene";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CanEnterMiniGame()) // ������ Ȯ�� (��: UI�� ���� ���� ��)
            {
                EnterMiniGame();
            }
        }
    }

    private bool CanEnterMiniGame()
    {
        // ����: ��ȣ�ۿ� ���� ������ �� �ְ�, UI�� ���� ���� �� ��
        return true;
    }

    private void EnterMiniGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(miniGameSceneName);
    }
}

