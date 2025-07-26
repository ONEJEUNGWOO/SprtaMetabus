using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetTileSceneTrigger : MonoBehaviour             //어떤 씬으로 전환 할지 정하고 값을 보내줄 클래스
{
    public string SceneName { get; set; }       //씬이름 정할 것
    public Canvas canvas;
    public Button startButton;
    public Button stopButton;
    public Button ruleButton;
    public TextMeshProUGUI ruleText;

    private void Start()
    {
        startButton.onClick.AddListener(NextScene);       //UI버튼 눌렀을 때 함수 실행하기
        stopButton.onClick.AddListener(ReturnMap);
        ruleButton.onClick.AddListener(RulePlay);
    }

    private void OnTriggerEnter2D(Collider2D collider)      //충돌하면 UI 키고 아니면 끄기
    {
        canvas.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
    }

    private void NextScene()        //Start 누르면 시작 Stop누르면 그냥 꺼지게 하는 함수
    {
        SceneChanger.Instance.SceneChange(tag);
    }

    private void ReturnMap()        //Stop 누르면 UI끄기
    {
        canvas.gameObject.SetActive(false);
    }

    private void RulePlay()         //누르면 룰 설명하기
    {
        startButton.gameObject.SetActive(false);        //방해되는 UI끄기
        stopButton.gameObject.SetActive(false);
        ruleButton.gameObject.SetActive(false);

        ruleText.gameObject.SetActive(true);
        StartCoroutine(AllReset(3f));
    }

    private IEnumerator AllReset(float delay)       //코르틴으로 3초후에 설명이랑 켄버스 세팅초기화 해주기
    {
        yield return new WaitForSeconds(delay);     //설정한 초 후에 아래 실행
        ruleText.gameObject.SetActive(false);       //꺼야할 UI끄기
        canvas.gameObject.SetActive(false);

        startButton.gameObject.SetActive(true);        //꺼뒀던 UI들 다시 키기
        stopButton.gameObject.SetActive(true);
        ruleButton.gameObject.SetActive(true);
    }
}
