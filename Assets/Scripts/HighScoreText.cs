using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScoreText();
    }

    void Update()
    {
        UpdateHighScoreText();
    }

    public void UpdateHighScoreText()
    {
        if (GameManager.Instance)
            highScoreText.text = "Best Score : " + GameManager.Instance.highScoreplayerName + " : " + GameManager.Instance.highScore.ToString();

    }
}
