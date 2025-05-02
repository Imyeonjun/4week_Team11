using UnityEngine;

public class PlayerController : BaseController // BaseController�� ��ӹ޴� �÷��̾� ���� ��Ʈ�ѷ�
{
    private Camera camera; // ���� ī�޶� ������ ���� (���콺 ��ġ�� ���� ��ǥ�� ��ȯ�ϱ� ���� ���)

    protected override void Start() // ���� ���� �� 1ȸ ȣ��Ǵ� �ʱ�ȭ �Լ�
    {
        base.Start(); // BaseController�� Start �Լ� ȣ�� (���� �ʱ�ȭ ����)
        camera = Camera.main; // ���� ���� Main Camera�� ������ ������ ����
    }

    protected override void HandleAction() // �� �����Ӹ��� ȣ��Ǿ� �Է��� ó���ϴ� �Լ�
    {
        // --- 1. �̵� �Է� ó�� ---

        // ���� �Է� �� �������� (A/D �Ǵ� ��/��)
        float horizontal = Input.GetAxisRaw("Horizontal");

        // ���� �Է� �� �������� (W/S �Ǵ� ��/��)
        float vertical = Input.GetAxisRaw("Vertical");

        // �Էµ� ������ ����ȭ�Ͽ� movementDirection�� ����
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // --- 2. ���콺 ���� ��� ---

        // ���� ���콺�� ȭ�� �ȼ� ��ǥ ��������
        Vector2 mousePosition = Input.mousePosition;

        // ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ (ī�޶� ����)
        Vector2 worldPosition = camera.ScreenToWorldPoint(mousePosition);

        // �÷��̾� ��ġ �������� ���콺������ ���� ���� ���
        lookDirection = (worldPosition - (Vector2)transform.position);

        // --- 3. ȸ�� ���� ���� ---

        // �ʹ� ����� �Ÿ��� ���� (���� ���·� ó��)
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            // ����ȭ�Ͽ� ���� ���ͷ� ����� ����
            lookDirection = lookDirection.normalized;
        }
    }
}

