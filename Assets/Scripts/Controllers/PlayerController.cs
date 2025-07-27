using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController      //�÷��̾ ������ ������ �޾ƿ��� Ŭ����
{
    private Camera MainCamera;  //ī�޶� �������� ���� ����� �δ� ����
    public bool isMoving;  //IsRun�ĸ����͸� Ű�� �������� ����

    protected override void Start()
    {
        base.Start();   //�̰� ������ �� �� ������ �� �Լ��ε� ���� ����ϴ��� �𸣰���
        MainCamera = Camera.main;   //����ī�޶� ��������
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //��ǲ�� �ִ� Ű�Ͱ��� Ű�� �ҷ����°� ����
        float vertical = Input.GetAxisRaw("Vertical"); // ���⵵

        movementDirection = new Vector2(horizontal, vertical).normalized;   //���⸸ ������ �ӵ��� 1�� ������ִ� �� (������ �� ���� �Ȱ�)

        Vector2 mousePosition = Input.mousePosition;        //���� �� ���콺 ��ġ�� �޾Ƽ�
        Vector2 worldPos = MainCamera.ScreenToWorldPoint(mousePosition);        //ī�޶� ��ġ ������ �������ִ� �۾�?
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)      // ���콺�� �� ĳ���� ��ġ�� 0.9f�̸����� ������ ���� ���� ���ϰ� �ϱ�
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
