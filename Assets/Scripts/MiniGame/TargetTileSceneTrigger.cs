using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTileSceneTrigger : MonoBehaviour             //어떤 씬으로 전환 할지 정하고 값을 보내줄 클래스
{
    public string SceneName { get; set; }       //씬이름 정할 것

    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneChanger.Instance.SceneChange(tag);
    }
}
