using UnityEngine;

public class BaseController : MonoBehaviour
{
    // Rigidbody2D 컴포넌트를 캐시하여 이동 처리에 사용
    protected Rigidbody2D _rigidbody;

    // 캐릭터의 스프라이트를 제어 (flipX로 좌우 반전)
    [SerializeField] private SpriteRenderer characterRenderer;

    // 입력에 따라 설정되는 이동 방향
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    // 마우스 방향 등으로 설정되는 시선 방향
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    // 컴포넌트 초기화 (어웨이크는 가장 먼저 실행됨)
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    // 매 프레임 호출, 입력 및 회전 처리 등 매 순간 업데이트가 필요한 처리.
    protected virtual void Update()
    {
        HandleAction();             // 입력 처리 (자식 클래스에서 구현)
        Rotate(lookDirection);      // 캐릭터 방향 회전 처리
    }

    // 물리 업데이트 (고정 시간 간격), 실제 이동 처리 수행
    protected virtual void FixedUpdate()
    {
        Movment(movementDirection); // 이동 처리
    }

    protected virtual void HandleAction()
    {

    }

    // 이동 처리 함수: 방향 * 속도를 Rigidbody2D에 적용
    private void Movment(Vector2 direction)
    {
        direction = direction * 5; // 이동 속도 설정 (5)
        _rigidbody.velocity = direction; // 물리적 이동 적용
    }

    // 캐릭터가 바라보는 방향에 따라 스프라이트 반전 처리
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 시선 각도 계산
        bool isLeft = Mathf.Abs(rotZ) > 90f; // 왼쪽을 보면 true

        characterRenderer.flipX = isLeft; // 좌우 반전
    }
}