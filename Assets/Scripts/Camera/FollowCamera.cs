using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour       //����ī�޶� Ÿ�� ���󰡴� Ŭ����
{
    [SerializeField] private Transform target;      //���� ������Ʈ? ��ü ã��
    private Vector3 position;                       //���� ��ġ ���� �Լ�

    void LateUpdate()
    {
        if (target == null)
            return;

        position = new Vector3(target.position.x,target.position.y,transform.localPosition.z);      //���� Ÿ�� ��ġ �־��ֱ�
        transform.position = position;      // z�� �÷��̾�� ������ �Ⱥ����� ���� ī�޶� z���� �־���
    }
}
