using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController : MonoBehaviour
{
    Text scoreText;
    collisionScores cScores;
    private void Awake()
    {
        cScores = FindObjectOfType<collisionScores>();
        scoreText = GetComponentInChildren<Text>();
    }
    private void OnEnable()
    {
        cScores.OnScoreChange += ScoreChange;
    }
    public void ScoreChange(int score) {
        scoreText.text = "SCORE: " + score + "/50";    
    }
}
