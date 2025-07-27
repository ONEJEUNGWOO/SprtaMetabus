using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController      //플레이어가 움직일 값들을 받아오는 클래스
{
    private Camera MainCamera;  //카메라 가져오기 위해 만들어 두는 변수
    public bool isMoving;  //IsRun파리미터를 키고 끄기위한 변수

    protected override void Start()
    {
        base.Start();   //이건 지워도 될 것 같은데 빈 함수인데 굳이 써야하는지 모르겠음
        MainCamera = Camera.main;   //메인카메라 가져오기
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //인풋에 있는 키와값을 키로 불러오는것 같음
        float vertical = Input.GetAxisRaw("Vertical"); // 여기도

        movementDirection = new Vector2(horizontal, vertical).normalized;   //방향만 가지고 속도는 1로 만들어주는 것 (솔직히 잘 이해 안감)

        Vector2 mousePosition = Input.mousePosition;        //지금 내 마우스 위치를 받아서
        Vector2 worldPos = MainCamera.ScreenToWorldPoint(mousePosition);        //카메라에 위치 값으로 변경해주는 작업?
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)      // 마우스가 내 캐릭터 위치랑 0.9f미만으로 가까우면 방향 변경 못하게 하기
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
