using UnityEngine;

public class MonsterSettingManager : MonoBehaviour
{
    public int monsterCount = 0;
    public Vector3 lastMonsterPosition = Vector3.zero;

    void Start()
    {
        // 씬에 있는 모든 MonsterSetting 컴포넌트를 찾음
        MonsterSetting[] monsters = GameObject.FindObjectsOfType<MonsterSetting>();

        if (monsters.Length == 0)
        {
            Debug.LogWarning("몬스터가 없습니다.");
            return;
        }

        // 첫 번째 몬스터 위치를 시작 기준점으로 사용
        lastMonsterPosition = monsters[0].transform.position;
        monsterCount = monsters.Length;

        // 초기 배치
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
