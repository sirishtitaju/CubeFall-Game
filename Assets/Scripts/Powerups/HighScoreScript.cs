using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {
	Text highscoreText;
	// Use this for initialization
	void Start () {
		highscoreText = GetComponent<Text>();
		highscoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();;
		checkHighScore();
	}
	void  checkHighScore()
	{
		if(ScoreScript.scoreValue > PlayerPrefs.GetInt("HighScore",0))
		{
		PlayerPrefs.SetInt("HighScore",ScoreScript.scoreValue);
		highscoreText.text = ScoreScript.scoreValue.ToString();
		}
	}
}
