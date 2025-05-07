using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSetting : MonoBehaviour
{
    [Header("���� ��ġ ���� (Y)")]
    public float minY;
    public float maxY;

    [Header("���� ����")]
    public float widthPadding = 4f;

    [Header("���� ������Ʈ")]
    public Transform monster;

    GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int monsterCount)
    {
        // X������ ���� ���� �̵�
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0, 0);

        // Y�� ��ġ�� ����
        placePosition.y = Random.Range(minY, maxY);

        // ������Ʈ ��ü ��ġ ����
        transform.position = placePosition;

        // ���� �ڽ� ������Ʈ�� �ִٸ� 0,0���� ����
        if (monster != null)
        {
            monster.localPosition = Vector3.zero;
        }

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Angel player = other.GetComponent<Angel>();
        if (player != null)
            gameManager.AddScore(1);
    }

}
