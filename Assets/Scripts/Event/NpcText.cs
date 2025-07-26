using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcText : MonoBehaviour        //npc�� ������ ��� �ؽ�Ʈ UI Ű�ų� ���ִ� Ŭ����
{
    public Canvas canvas;                   //���� ų ĵ���� ��������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canvas.gameObject.SetActive(true);     //�浹 �ϸ� UI �ѱ�
        StartCoroutine(HideCanvasAfterDelay(3f));  //3�� ��ٸ��� ���ؼ� �ڸ�ƾ���� �Լ� �θ���
    }

    private IEnumerator HideCanvasAfterDelay(float delay)       //���� �μ� ��ŭ �� ��ٷȴ� ���� �Լ�
    {
        yield return new WaitForSeconds(delay);     //���� ��ٸ��� ���ϱ�
        canvas.gameObject.SetActive(false);         //UI ����
    }
}
