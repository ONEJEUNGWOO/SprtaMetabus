using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    Button startButton;
    Button exitButton;

    public override UIState GetUIStates()
    {
        return UIState.Home;
    }

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickStartButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }
    public void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
