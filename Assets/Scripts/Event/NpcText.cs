using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcText : MonoBehaviour        //npc와 접촉할 경우 텍스트 UI 키거나 꺼주는 클래스
{
    public Canvas canvas;                   //껏다 킬 캔버스 가져오기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canvas.gameObject.SetActive(true);     //충돌 하면 UI 켜기
        StartCoroutine(HideCanvasAfterDelay(3f));  //3초 기다리기 위해서 코르틴으로 함수 부르기
    }

    private IEnumerator HideCanvasAfterDelay(float delay)       //받은 인수 만큼 초 기다렸다 끄는 함수
    {
        yield return new WaitForSeconds(delay);     //몇초 기다릴지 정하기
        canvas.gameObject.SetActive(false);         //UI 끄기
    }
}
