using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour {

	void Start()
	{
		// Destroy(gameObject,10);	
		// GameManager.createdCherry = false;
	}
	
    void OnTriggerEnter2D(Collider2D co) {
        if  (co.name == "pacman")
            {
                //increase score 
                ScoreScript.scoreValue = ScoreScript.scoreValue + ScoreScript.cherryValue;
                SoundManagerScript.PlaySound("eat_fruit");                
			    Destroy(gameObject);
				GameManager.createdCherry = false;
            }
    }
}
