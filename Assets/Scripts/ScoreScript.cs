using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour {

//Scoring const values: pacdot, pellet
public const int pacdotValue = 10;
public const int pelletValue = 50;
public const int cherryValue = 100;

//Scoring variables
public static int scoreValue = 0;
public static int highScoreValue = 0;
public static int cantPellets = 0;
public static int cantPacdots = 0;
public static int totalPacdots = 0;


	Text ScoreText;
	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreValue > highScoreValue)
		{
			highScoreValue = scoreValue;
		}
		ScoreText.text = scoreValue.ToString("0000")+" HIGH SCORE "
						+ highScoreValue.ToString("0000")
						+ " LEVEL "+GameManager.level.ToString("0000");
	}
	
}
