using UnityEngine;

public class BaseController : MonoBehaviour
{
    // Rigidbody2D ������Ʈ�� ĳ���Ͽ� �̵� ó���� ���
    protected Rigidbody2D _rigidbody;

    // ĳ������ ��������Ʈ�� ���� (flipX�� �¿� ����)
    [SerializeField] private SpriteRenderer characterRenderer;

    // �Է¿� ���� �����Ǵ� �̵� ����
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    // ���콺 ���� ������ �����Ǵ� �ü� ����
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    // ������Ʈ �ʱ�ȭ (�����ũ�� ���� ���� �����)
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    // �� ������ ȣ��, �Է� �� ȸ�� ó�� �� �� ���� ������Ʈ�� �ʿ��� ó��.
    protected virtual void Update()
    {
        HandleAction();             // �Է� ó�� (�ڽ� Ŭ�������� ����)
        Rotate(lookDirection);      // ĳ���� ���� ȸ�� ó��
    }

    // ���� ������Ʈ (���� �ð� ����), ���� �̵� ó�� ����
    protected virtual void FixedUpdate()
    {
        Movment(movementDirection); // �̵� ó��
    }

    protected virtual void HandleAction()
    {

    }

    // �̵� ó�� �Լ�: ���� * �ӵ��� Rigidbody2D�� ����
    private void Movment(Vector2 direction)
    {
        direction = direction * 5; // �̵� �ӵ� ���� (5)
        _rigidbody.velocity = direction; // ������ �̵� ����
    }

    // ĳ���Ͱ� �ٶ󺸴� ���⿡ ���� ��������Ʈ ���� ó��
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // �ü� ���� ���
        bool isLeft = Mathf.Abs(rotZ) > 90f; // ������ ���� true

        characterRenderer.flipX = isLeft; // �¿� ����
    }
}