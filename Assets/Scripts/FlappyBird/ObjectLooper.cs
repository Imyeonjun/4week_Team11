using UnityEngine;

public class ObjectLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int monsterCount = 0;
    public Vector3 lastMonsterPosition = Vector3.zero;

    void Start()
    {
        // 초기 몬스터 설정
        MonsterSetting[] monsters = GameObject.FindObjectsOfType<MonsterSetting>();
        if (monsters.Length == 0)
        {
            Debug.LogWarning("MonsterSetting 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        lastMonsterPosition = monsters[0].transform.position;
        monsterCount = monsters.Length;

        for (int i = 0; i < monsterCount; i++)
        {
            lastMonsterPosition = monsters[i].SetRandomPlace(lastMonsterPosition, monsterCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 배경 반복 배치 처리
        if (collision.CompareTag("Map"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount + 20;
            collision.transform.position = pos;
            return;
        }

        // 몬스터 반복 배치 처리
        MonsterSetting monster = collision.GetComponent<MonsterSetting>();
        if (monster)
        {
            lastMonsterPosition = monster.SetRandomPlace(lastMonsterPosition, monsterCount);
        }
    }
}
