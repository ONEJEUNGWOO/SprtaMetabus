using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour           // �� ��ȯ�� Ŭ����
{
    public static SceneChanger Instance { get; private set; }

    public int hasVisitet = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   // �ߺ� ����
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // �� ��ȯ�ص� �������� �ʰ�
    }

    /**�� �̸� ��Ʈ�������� �޾Ƽ� �־��ָ� �� ������ �ٲ��ִ� �Լ�**/
    public void SceneChange(string sceneName)
    {
        hasVisitet++;
        SceneManager.LoadScene(sceneName);
    }

}
