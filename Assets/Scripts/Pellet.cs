using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {
    
    private SpriteRenderer spriteRenderer;
	float timer = 0.15f;

    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pacman") 
            {
                ScoreScript.scoreValue = ScoreScript.scoreValue + ScoreScript.pelletValue;
                ScoreScript.cantPellets++;
			    Destroy(gameObject);
            }
    }
  
	// Use this for initialization
	void Start () {
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
  		StartCoroutine(Blink());
	}
	
	public IEnumerator Blink() {
	// blink it forever. You can set a terminating condition depending upon your requirement
		while (true) {
			spriteRenderer.enabled = true;
			yield return new WaitForSeconds(timer);
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(timer);
		}
	}
}
