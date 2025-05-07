using UnityEngine;

public class PrefabSetting : MonoBehaviour
{
    [Header("��� ������")]
    public GameObject prefabs;

    [Header("���� ���� (X, Y)")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [Header("��� ����")]
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
            Debug.LogError("�������� �������� �ʾҽ��ϴ�.");
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
