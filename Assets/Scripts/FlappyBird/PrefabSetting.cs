using UnityEngine;

public class PrefabSetting : MonoBehaviour
{
    [Header("배경 프리팹")]
    public GameObject prefabs;

    [Header("생성 범위 (X, Y)")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [Header("배경 간격")]
    public float spacingX = 1.0f;
    public float spacingY = 1.0f;

    void Start()
    {
        SettingBackground();
    }

    void SettingBackground()
    {
        if (prefabs == null)
        {
            Debug.LogError("프리팹이 지정되지 않았습니다.");
            return;
        }

        for (float x = minX; x <= maxX; x++)
        {
            for (float y = minY; y <= maxY; y++)
            {
                Vector3 position = new Vector3(x * spacingX, y * spacingY, 0);
                Instantiate(prefabs, position, Quaternion.identity, transform);
            }
        }
    }
}
