using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByY : MonoBehaviour
{
    public int orderOffset = 1000;  // 맵보다 앞에 오도록 충분히 큰 값

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
