using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour     //�� �⺯�� �̵� �� ������ ó���ϴ� Ŭ����, ���� ���� �޾ƿ��� �� ����.
{
    protected Rigidbody2D _rigid;  //�θ� �̵��ϴ� ����̱� ������ �θ� ������ �ٵ� ���� ���� ����
    [SerializeField] private SpriteRenderer characterRenderer;  //�θ� �ν����Ϳ��� �̸� �ڽĵ� ���ϴ°� �޾Ƶα� ���� �ִϸ����͸� �޾� �;� �� �����־��
    [SerializeField] private Transform weaponPivot;             //GetComponent ���ϱ� ���� ���� �ǰ�?
    [SerializeField] private Animator characterAnimator;         //�ִϸ����� ��ȯ�ϱ� ����

    protected Vector2 movementDirection = Vector2.zero;         //�ڽ� Ŭ�������� �̵� ���� �޾ƿ��� ���� ���� ����
    public Vector2 MovementDirection { get { return movementDirection;}}    //ĸ��ȭ? �������� �� ������ ��� �� �𸣰���

    protected Vector2 lookDirection = Vector2.zero; // ���Ⱚ �޾ƿ� ����
    public Vector2 LookDirection { get { return lookDirection; } }      //ĸ��ȭ


    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); //������ �θ� ������ٵ� �̸� ��������
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);        //���� �ٲ�� ���� �ϴ� �� ����
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)    //�������� ����� �Լ�
    {
        direction = direction * 5;  //��ֶ����� �� �ӵ��� �ٽ� ���� ������ (�ٵ� ������ �� �ȹٲ���� �� �𸣰���)

        _rigid.velocity = direction;    //���⼭ �̵��� ���� �־���
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //������ �� �𸣰����� ���� �ִ� ���� ���ش� �� ����
        Debug.Log($"rotz�� {rotZ}");
        bool isLeft = rotZ > 135f || rotZ <= -135f;     //���� ���� ������ bool������ ��ȯ�ϴ� ����
        bool isRight = rotZ > -45f && rotZ <= 45f;      
        bool isTop = rotZ > 45f && rotZ <= 135f;
        bool isDown = rotZ > -135f && rotZ <= -45f;

        if (isTop || isDown)                                        //���� �Ʒ��� ���� �ִϸ����Ϳ� IsLeftMove�� ��
            characterAnimator.SetBool("IsLeftMove", false);

        if (isLeft || isRight)                                      //�����̳� �������� ���� �ִϸ����Ϳ� IsTopMove�� ��
            characterAnimator.SetBool("IsTopMove", false);

        if (!isDown)                                                //�Ʒ� �Ⱥ��� ��
            characterAnimator.SetBool("IsMove", false);


        characterRenderer.flipX = !isLeft;   // ��������Ʈ �¿� ���� �ִϸ��̼� �ϳ��� �������� ����ϱ� ���� ����
       
        if (isLeft || isRight)              //�ִϸ����� �۵��ϱ� ���� ���ǽ�
            characterAnimator.SetBool("IsLeftMove", true);
        if (isTop)
            characterAnimator.SetBool("IsTopMove", true);
        if (isDown)
            characterAnimator.SetBool("IsMove", true);


        if (weaponPivot != null)  // ���� ���Ⱑ �ִٸ� ���� ȸ�� ó�� �ִϸ����ͷ� �̵��ϸ� �Ⱦ�����
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}
