using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerBird : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button returnButton;

    // Start is called before the first frame update
    void Start()
    {
        
        if (scoreText == null)
            Debug.LogError("score null");

        restartButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);


    }

    public void SetRestart()
    {
        restartButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
