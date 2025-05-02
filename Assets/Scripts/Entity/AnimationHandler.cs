using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator �Ķ���� �̸��� �ؽð����� ��ȯ�� ���� (���� ����ȭ��)
    private static readonly int isMoving = Animator.StringToHash("isMove");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>(); // �ڽ� ������Ʈ���� Animator ������Ʈ�� ã�� �Ҵ�
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(isMoving, obj.magnitude > .5f); // �̵� �ӵ��� ���� �̻��� �� '�̵� ��' �ִϸ��̼� ����
    }
}
