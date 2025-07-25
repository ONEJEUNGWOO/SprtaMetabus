using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour       //메인카메라가 타겟 따라가는 클래스
{
    [SerializeField] private Transform target;      //따라갈 오브젝트? 객체 찾기
    private Vector3 position;                       //따라갈 위치 담을 함수

    void LateUpdate()
    {
        if (target == null)
            return;

        position = new Vector3(target.position.x,target.position.y,transform.localPosition.z);      //따라갈 타겟 위치 넣어주기
        transform.position = position;      // z가 플레이어랑 같으면 안보여서 원래 카메라 z값을 넣어줌
    }
}
