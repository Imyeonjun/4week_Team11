using UnityEngine;

public class PlayerController : BaseController // BaseController를 상속받는 플레이어 전용 컨트롤러
{
    private Camera camera; // 메인 카메라를 참조할 변수 (마우스 위치를 월드 좌표로 변환하기 위해 사용)

    protected override void Start() // 게임 시작 시 1회 호출되는 초기화 함수
    {
        base.Start(); // BaseController의 Start 함수 호출 (상위 초기화 유지)
        camera = Camera.main; // 현재 씬의 Main Camera를 가져와 변수에 저장
    }

    protected override void HandleAction() // 매 프레임마다 호출되어 입력을 처리하는 함수
    {
        // --- 1. 이동 입력 처리 ---

        // 수평 입력 값 가져오기 (A/D 또는 ←/→)
        float horizontal = Input.GetAxisRaw("Horizontal");

        // 수직 입력 값 가져오기 (W/S 또는 ↑/↓)
        float vertical = Input.GetAxisRaw("Vertical");

        // 입력된 방향을 정규화하여 movementDirection에 저장
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // --- 2. 마우스 방향 계산 ---

        // 현재 마우스의 화면 픽셀 좌표 가져오기
        Vector2 mousePosition = Input.mousePosition;

        // 화면 좌표를 월드 좌표로 변환 (카메라 기준)
        Vector2 worldPosition = camera.ScreenToWorldPoint(mousePosition);

        // 플레이어 위치 기준으로 마우스까지의 방향 벡터 계산
        lookDirection = (worldPosition - (Vector2)transform.position);

        // --- 3. 회전 방향 설정 ---

        // 너무 가까운 거리면 무시 (정지 상태로 처리)
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            // 정규화하여 단위 벡터로 만들어 저장
            lookDirection = lookDirection.normalized;
        }
    }
}

