using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetTileSceneTrigger : MonoBehaviour             //� ������ ��ȯ ���� ���ϰ� ���� ������ Ŭ����
{
    public string SceneName { get; set; }       //���̸� ���� ��
    public Canvas canvas;
    public Button startButton;
    public Button stopButton;
    public Button ruleButton;
    public TextMeshProUGUI ruleText;

    private void Start()
    {
        startButton.onClick.AddListener(NextScene);       //UI��ư ������ �� �Լ� �����ϱ�
        stopButton.onClick.AddListener(ReturnMap);
        ruleButton.onClick.AddListener(RulePlay);
    }

    private void OnTriggerEnter2D(Collider2D collider)      //�浹�ϸ� UI Ű�� �ƴϸ� ����
    {
        canvas.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
    }

    private void NextScene()        //Start ������ ���� Stop������ �׳� ������ �ϴ� �Լ�
    {
        SceneChanger.Instance.SceneChange(tag);
    }

    private void ReturnMap()        //Stop ������ UI����
    {
        canvas.gameObject.SetActive(false);
    }

    private void RulePlay()         //������ �� �����ϱ�
    {
        startButton.gameObject.SetActive(false);        //���صǴ� UI����
        stopButton.gameObject.SetActive(false);
        ruleButton.gameObject.SetActive(false);

        ruleText.gameObject.SetActive(true);
        StartCoroutine(AllReset(3f));
    }

    private IEnumerator AllReset(float delay)       //�ڸ�ƾ���� 3���Ŀ� �����̶� �˹��� �����ʱ�ȭ ���ֱ�
    {
        yield return new WaitForSeconds(delay);     //������ �� �Ŀ� �Ʒ� ����
        ruleText.gameObject.SetActive(false);       //������ UI����
        canvas.gameObject.SetActive(false);

        startButton.gameObject.SetActive(true);        //���״� UI�� �ٽ� Ű��
        stopButton.gameObject.SetActive(true);
        ruleButton.gameObject.SetActive(true);
    }
}
