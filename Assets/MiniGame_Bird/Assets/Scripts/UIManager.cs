using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerBird : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.LogError("restart null");
        
        if (scoreText == null)
            Debug.LogError("score null");

        restartText.gameObject.SetActive(false);


    }

    public void SetRestart()
    {
        SceneChanger.Instance.SceneChange("MainScene");
        //restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
