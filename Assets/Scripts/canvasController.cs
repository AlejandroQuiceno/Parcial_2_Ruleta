using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController : MonoBehaviour
{
    [SerializeField]Text scoreText;
    collisionScores cScores;
    public int aScore;

    private void Awake()
    {
        cScores = FindObjectOfType<collisionScores>();
    }
    private void OnEnable()
    {
        cScores.OnScoreChange += ScoreChange;
    }
    private void OnDisable()
    {
        cScores.OnScoreChange -= ScoreChange;
    }
    public void ScoreChange(int score) {
        int actualScore = int.Parse(scoreText.text);
        if (actualScore + score < 0) actualScore = 0;
        else
        {
            actualScore += score;
        }
        scoreText.text = actualScore.ToString();
        aScore = actualScore;
    }
}
