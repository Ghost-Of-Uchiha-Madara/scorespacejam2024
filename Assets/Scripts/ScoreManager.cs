using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highScoreText;

    public float highScore;

    int totalPoints;

    private void Start()
    {
        //highScore = PlayerPrefs.GetInt("HighScore", 0);

        totalPoints = GameManager.instance.totalPoints;

        //GameManager.instance.AddTimeBonus();
        scoreText.text = GameManager.instance.totalPoints.ToString();

        if (totalPoints > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)totalPoints);
            //highScoreText.text = scoreAmount.ToString("00");
        }
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();  
    }
}
