using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTileSceneTrigger : MonoBehaviour             //� ������ ��ȯ ���� ���ϰ� ���� ������ Ŭ����
{
    public string SceneName { get; set; }       //���̸� ���� ��

    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneChanger.Instance.SceneChange(tag);
    }
}
