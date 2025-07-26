using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerBird : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nowScoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject scoreBord;
    public Button restartButton;
    public Button returnButton;

    int bestScore = 0;
    public int BestScore { 
        get { return bestScore; } 
        set { if (value <= bestScore) return; else bestScore = value; } }

    private const string BestScoreKey = "BestScore";

    // Start is called before the first frame update
    void Start()
    {
        
        if (scoreText == null)
            Debug.LogError("score null");

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestScoreText.text = bestScore.ToString();

        restartButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        scoreBord.SetActive(false);
    }

    public void SetRestart()
    {
        restartButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        scoreBord.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(BestScoreKey, score);
            PlayerPrefs.Save();
        }

        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
        nowScoreText.text = score.ToString();
    }

}
