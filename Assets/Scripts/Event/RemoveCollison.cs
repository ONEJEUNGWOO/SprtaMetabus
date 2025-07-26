using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveCollison : MonoBehaviour         //미니게임 점수를 통과해야만 다음 지역이동 가능하게 해주는 클래스
{
    int score;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("BestScore");        // 미니게임 점수를 받아온다 나중에 게임에 따라 키이름을 다르게 줘야겠음
    }

    private void Update()
    {
        if (SceneChanger.Instance.hasVisitet != 0)      //게임을 시작했을 땐 미니게임 한번이상 다녀와야 벽이 열리게 하는 조건식
        {
            if (score >= 30)
            {
                this.gameObject.SetActive(false);
            }
        }
        else return;
    }
}
