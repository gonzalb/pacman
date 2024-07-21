using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public float restartDelay = 4f;
	public static bool GameOver = false;
	public static bool restartLevel = false;
	public static int level = 0;
	public static int PacmanLifes = 5;
	public static bool createdCherry = false;
	public Transform[] PacmanLifesSprites;
    public Transform cherry;


	//x 17.5 y 14
    
	// Use this for initialization
	void Start () {
		SoundManagerScript.PlaySound("start");
	}	
	
	// Update is called once per frame
	void Update () {

		CheckActualStatus();

		if (((ScoreScript.cantPacdots  == 70) || (ScoreScript.cantPacdots  == 170)) 
			& !createdCherry)
		{
			CreateCherry();
		}

		if (GameOver)
		{
			Debug.Log("You Lose! " + ScoreScript.scoreValue );
			Debug.Log("speed " + GhostMove.speed );
			Invoke("RestartGame", restartDelay);
		}

		if (restartLevel)
		{
			Debug.Log("Restart Level " + ScoreScript.scoreValue );
			Debug.Log("speed " + GhostMove.speed );			
			Invoke("RestartLevelRoutine", restartDelay);
		}

		if (ScoreScript.cantPacdots == PacdotCreator.totalPacdots)
		{
			Debug.Log("You Win! " + ScoreScript.scoreValue );
			Debug.Log("speed " + GhostMove.speed );			
			Invoke("NextLevel", restartDelay);
		}
	}

	void CheckActualStatus()
	{
		GameOver = (PacmanLifes == 0);
		for (int i = 0; i <=3 ; i++)
		{
			if ((i+1) < PacmanLifes)
			{			
				PacmanLifesSprites[i].GetComponent<SpriteRenderer>().enabled = true;
			}
			else
			{
				PacmanLifesSprites[i].GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}

	void NextLevel()
	{
		GameOver = false;
		restartLevel = false;
		ScoreScript.cantPacdots = 0;
		createdCherry = false;
		level++;
		GhostMove.speed = GhostMove.speed + 0.1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void RestartLevelRoutine()
	{		
		GameOver = false;
		restartLevel = false;		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void RestartGame()
	{
		level = 0;
		GameOver = false;
		restartLevel = false;
		PacmanLifes = 5;
		ScoreScript.cantPacdots = 0;
		ScoreScript.scoreValue = 0;
		GhostMove.speed = 0.2f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void CreateCherry()
	{
		Instantiate(cherry, new Vector2(15, 14), Quaternion.identity);
		createdCherry = true;
	}
}
