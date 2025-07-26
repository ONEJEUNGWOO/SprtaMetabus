using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour           // 씬 전환용 클래스
{
    public static SceneChanger Instance { get; private set; }

    public int hasVisitet = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   // 중복 방지
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환해도 지워지지 않게
    }

    /**씬 이름 스트링값으로 받아서 넣어주면 그 씬으로 바꿔주는 함수**/
    public void SceneChange(string sceneName)
    {
        hasVisitet++;
        SceneManager.LoadScene(sceneName);
    }

}
