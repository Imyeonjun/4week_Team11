using UnityEngine;

public class MonsterSettingManager : MonoBehaviour
{
    public int monsterCount = 0;
    public Vector3 lastMonsterPosition = Vector3.zero;

    void Start()
    {
        // ���� �ִ� ��� MonsterSetting ������Ʈ�� ã��
        MonsterSetting[] monsters = GameObject.FindObjectsOfType<MonsterSetting>();

        if (monsters.Length == 0)
        {
            Debug.LogWarning("���Ͱ� �����ϴ�.");
            return;
        }

        // ù ��° ���� ��ġ�� ���� ���������� ���
        lastMonsterPosition = monsters[0].transform.position;
        monsterCount = monsters.Length;

        // �ʱ� ��ġ
        for (int i = 0; i < monsterCount; i++)
        {
            lastMonsterPosition = monsters[i].SetRandomPlace(lastMonsterPosition, monsterCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        MonsterSetting monster = collision.GetComponent<MonsterSetting>();
        if (monster)
        {
            lastMonsterPosition = monster.SetRandomPlace(lastMonsterPosition, monsterCount);
        }
    }
}
