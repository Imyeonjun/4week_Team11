using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByY : MonoBehaviour
{
    public int orderOffset = 1000;  // �ʺ��� �տ� ������ ����� ū ��

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100) + orderOffset;
    }
}
