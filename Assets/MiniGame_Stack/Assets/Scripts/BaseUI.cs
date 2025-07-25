using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uiManager = uIManager;
    }

    public abstract UIState GetUIStates();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIStates() == state);
    }


}
