using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator 파라미터 이름을 해시값으로 변환해 저장 (성능 최적화용)
    private static readonly int isMoving = Animator.StringToHash("isMove");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>(); // 자식 오브젝트에서 Animator 컴포넌트를 찾아 할당
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(isMoving, obj.magnitude > .5f); // 이동 속도가 일정 이상일 때 '이동 중' 애니메이션 실행
    }
}
