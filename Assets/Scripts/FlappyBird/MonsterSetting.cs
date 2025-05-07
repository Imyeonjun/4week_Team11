using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSetting : MonoBehaviour
{
    [Header("몬스터 배치 범위 (Y)")]
    public float minY;
    public float maxY;

    [Header("가로 간격")]
    public float widthPadding = 4f;

    [Header("몬스터 오브젝트")]
    public Transform monster;

    GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int monsterCount)
    {
        // X축으로 일정 간격 이동
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0, 0);

        // Y축 위치는 랜덤
        placePosition.y = Random.Range(minY, maxY);

        // 오브젝트 자체 위치 설정
        transform.position = placePosition;

        // 몬스터 자식 오브젝트가 있다면 0,0으로 정렬
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
