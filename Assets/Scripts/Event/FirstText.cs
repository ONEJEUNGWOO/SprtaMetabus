using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstText : MonoBehaviour                  //특정 장소 갔을 때 대사보이게 하기
{
    public Canvas canvas;       //캔버스 껐다키기 위해서 가져오기

    private void OnTriggerEnter2D(Collider2D collider)
    {
        canvas.gameObject.SetActive(true);              //충돌하면 대사 보이게 하기
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvas.gameObject.SetActive(false);             //충돌 끝나면 끄기
    }
}
