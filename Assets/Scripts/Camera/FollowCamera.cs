using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour       //����ī�޶� Ÿ�� ���󰡴� Ŭ����
{
    [SerializeField] private Transform target;      // ���� ���
    [SerializeField] private float minX, maxX, minY, maxY;  // ī�޶� �̵� ���� ����

    private Vector3 position;       // ���� ��ġ ���� ����

    void LateUpdate()
    {
        if (target == null)
            return;

        // Ÿ�� ��ġ�� ��������, X, Y�� ���󰡰� Z�� ī�޶� �ڽ��� z ����
        float targetX = Mathf.Clamp(target.position.x, minX, maxX);
        float targetY = Mathf.Clamp(target.position.y, minY, maxY);

        position = new Vector3(targetX, targetY, transform.position.z);
        transform.position = position;
    }
}
