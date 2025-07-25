using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour     //방 향변경 이동 등 동작을 처리하는 클래스, 값은 따로 받아오는 것 같다.
{
    protected Rigidbody2D _rigid;  //부모를 이동하는 방식이기 때문에 부모에 리지드 바디를 담을 변수 생성
    [SerializeField] private SpriteRenderer characterRenderer;  //부모에 인스펙터에서 미리 자식들 원하는거 받아두기 나는 애니메이터를 받아 와야 할 수도있어보임
    [SerializeField] private Transform weaponPivot;             //GetComponent 안하기 위해 쓰는 건가?
    [SerializeField] private Animator characterAnimator;         //애니메이터 변환하기 위해

    protected Vector2 movementDirection = Vector2.zero;         //자식 클래스에서 이동 값을 받아오기 위해 만든 변수
    public Vector2 MovementDirection { get { return movementDirection;}}    //캡슐화? 아직까지 왜 쓰는지 사실 잘 모르겠음

    protected Vector2 lookDirection = Vector2.zero; // 방향값 받아올 변수
    public Vector2 LookDirection { get { return lookDirection; } }      //캡슐화


    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); //움직일 부모에 리지드바디 미리 가져오기
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
        Movement(movementDirection);        //값이 바뀌면 실행 하는 것 같음
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)    //움직임을 담당할 함수
    {
        direction = direction * 5;  //노멀라이즈 한 속도를 다시 증가 시켜줌 (근데 방향은 왜 안바뀌는지 잘 모르겠음)

        _rigid.velocity = direction;    //여기서 이동함 값을 넣어줌
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //수식은 잘 모르겠지만 보고 있는 값을 구해는 것 같음
        Debug.Log($"rotz값 {rotZ}");
        bool isLeft = rotZ > 135f || rotZ <= -135f;     //현재 보는 방향을 bool값으로 반환하는 변수
        bool isRight = rotZ > -45f && rotZ <= 45f;      
        bool isTop = rotZ > 45f && rotZ <= 135f;
        bool isDown = rotZ > -135f && rotZ <= -45f;

        if (isTop || isDown)                                        //위나 아래를 보면 애니메이터에 IsLeftMove를 끔
            characterAnimator.SetBool("IsLeftMove", false);

        if (isLeft || isRight)                                      //왼쪽이나 오른쪽을 보면 애니메이터에 IsTopMove를 끔
            characterAnimator.SetBool("IsTopMove", false);

        if (!isDown)                                                //아래 안보면 끔
            characterAnimator.SetBool("IsMove", false);


        characterRenderer.flipX = !isLeft;   // 스프라이트 좌우 반전 애니메이션 하나를 반전으로 사용하기 위해 썼음
       
        if (isLeft || isRight)              //애니메이터 작동하기 위한 조건식
            characterAnimator.SetBool("IsLeftMove", true);
        if (isTop)
            characterAnimator.SetBool("IsTopMove", true);
        if (isDown)
            characterAnimator.SetBool("IsMove", true);


        if (weaponPivot != null)  // 현재 무기가 있다면 무기 회전 처리 애니메이터로 이동하면 안쓸수도
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}
