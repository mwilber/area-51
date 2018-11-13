using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int pointsPerKill = 1;

    int score = 0;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        UpdateScoreBoard();
	}

    public void ScoreHit()
    {
        score += pointsPerKill;
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard(){
        string scoreString = score.ToString() + " kills";
        scoreText.text = scoreString;
    }
}
