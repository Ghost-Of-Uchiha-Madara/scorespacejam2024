using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highScoreText;

    private void Start()
    {
        GameManager.instance.AddTimeBonus();
        scoreText.text = GameManager.instance.totalPoints.ToString();
    }
}
