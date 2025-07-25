using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour       //메인카메라가 타겟 따라가는 클래스
{
    [SerializeField] private Transform target;      // 따라갈 대상
    [SerializeField] private float minX, maxX, minY, maxY;  // 카메라 이동 제한 범위

    private Vector3 position;       // 따라갈 위치 담을 변수

    void LateUpdate()
    {
        if (target == null)
            return;

        // 타겟 위치를 기준으로, X, Y는 따라가고 Z는 카메라 자신의 z 유지
        float targetX = Mathf.Clamp(target.position.x, minX, maxX);
        float targetY = Mathf.Clamp(target.position.y, minY, maxY);

        position = new Vector3(targetX, targetY, transform.position.z);
        transform.position = position;
    }
}
