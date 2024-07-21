using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D co) {
        if  (co.name == "pacman")
            {
                //increase score 
                ScoreScript.scoreValue = ScoreScript.scoreValue + ScoreScript.pacdotValue;
                ScoreScript.cantPacdots++;
                SoundManagerScript.PlaySound("munch_1");                
			    Destroy(gameObject);
            }

    }
}