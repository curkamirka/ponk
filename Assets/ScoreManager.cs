using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    public int leftScore;
    public int rightScore;

    public void IncrementLeftPlayerScore()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
    }

    public void IncrementRightPlayerScore()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
    }
    
}
