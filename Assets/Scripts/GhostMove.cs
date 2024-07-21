using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {
    public Transform[] InitWaypoints;
    public Transform[] ScatterWaypoints;

    int init_cur = 0;
    int scatter_cur = 0;

    public static float speed = 0.2f;

	enum State { Wait, Init, Scatter, Chase, Frightned};
	State state;

	void Start () {
		state = State.Init;
	}	
			   
	void FixedUpdate () {
		switch (state)
        {
            case State.Init: 
				InitMove();
	            break;
            case State.Scatter:
				ScatterMove();
                break;
			case State.Frightned:
				FrightnedMove();
                break;
        }	
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman")
		{
	        co.GetComponent<Animator>().SetBool("IsDead", true);
			Destroy(co.gameObject,3);			
			SoundManagerScript.PlaySound("death");	 
			GameManager.PacmanLifes--;
			GameManager.restartLevel = true;
		}
			
	}

	private void InitMove()
	{
		//Animation
		Vector2 dir = InitWaypoints[init_cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
		
		//Waypoint not reached yet? then move closer
		if (transform.position != InitWaypoints[init_cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
											InitWaypoints[init_cur].position,
											speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		//Waypoint reached, select next one
		else 
		{
			init_cur++;
			//Waypoint limit reached, then move to next state (Scatter)
			if (init_cur == InitWaypoints.Length) {state = State.Scatter;}
		}		
	}

	private void ScatterMove()
	{
		//Waypoint not reached yet? then move closer
		if (transform.position != ScatterWaypoints[scatter_cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
											ScatterWaypoints[scatter_cur].position,
											speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		//Waypoint reached, select next one
		else 
		{
			scatter_cur = (scatter_cur + 1) % ScatterWaypoints.Length;
		}
		//Animation
		Vector2 dir = ScatterWaypoints[scatter_cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);		
	}

	private void FrightnedMove()
	{
		//Waypoint not reached yet? then move closer
		if (transform.position != ScatterWaypoints[scatter_cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
											ScatterWaypoints[scatter_cur].position,
											speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		//Waypoint reached, select next one
		else 
		{
			scatter_cur = (scatter_cur + 1) % ScatterWaypoints.Length;
		}
		//Animation
		Vector2 dir = ScatterWaypoints[scatter_cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);		
	}
}
