using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacdotCreator : MonoBehaviour {
    public Transform pacdoc;
	public Transform pellet;
	public float offset = 0.0f;
	public static int totalPacdots;
	public static int totalPellets;


	private int maxPosX = 29;
	private int maxPosY = 31;
	private Vector2[] pelletVectors = {new Vector2(3,8), new Vector2(3,26), new Vector2(28,26), new Vector2(28,8)}; 

	// Use this for initialization
	void Start () {	
			totalPacdots = 0;	
			totalPellets = 0;
			CreatePellets();
			CreatePacdots();
	}

	private void CreatePacdots()
	{
		for (int i = 2; i < maxPosX; i++)
        {
			for (int j = 2; j < maxPosY; j++)
			{
				float x = (i*1.0f) + offset;
				float y = (j*1.0f) + offset;
				//check for collision with a maze wall
				if (null == Physics2D.OverlapCircle(new Vector2(x,y), 0.45f))
				{
					Instantiate(pacdoc, new Vector2(x,y), Quaternion.identity);
					totalPacdots++;
				}
			}
		}
	}

	private void CreatePellets()
	{
		for (int i = 0; i < 4; i++)
		{
			Instantiate(pellet, pelletVectors[i], Quaternion.identity);	
			totalPellets++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}	
}
