using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstText : MonoBehaviour                  //Ư�� ��� ���� �� ��纸�̰� �ϱ�
{
    public Canvas canvas;       //ĵ���� ����Ű�� ���ؼ� ��������

    private void OnTriggerEnter2D(Collider2D collider)
    {
        canvas.gameObject.SetActive(true);              //�浹�ϸ� ��� ���̰� �ϱ�
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvas.gameObject.SetActive(false);             //�浹 ������ ����
    }
}
