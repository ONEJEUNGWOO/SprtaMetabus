using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveCollison : MonoBehaviour         //�̴ϰ��� ������ ����ؾ߸� ���� �����̵� �����ϰ� ���ִ� Ŭ����
{
    int score;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("BestScore");        // �̴ϰ��� ������ �޾ƿ´� ���߿� ���ӿ� ���� Ű�̸��� �ٸ��� ��߰���
    }

    private void Update()
    {
        if (SceneChanger.Instance.hasVisitet != 0)      //������ �������� �� �̴ϰ��� �ѹ��̻� �ٳ�;� ���� ������ �ϴ� ���ǽ�
        {
            if (score >= 30)
            {
                this.gameObject.SetActive(false);
            }
        }
        else return;
    }
}
