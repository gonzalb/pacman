using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public static AudioClip munch1Sound;
	public static AudioClip munch2Sound;
	public static AudioClip startSound;
	public static AudioClip deathSound;
	public static AudioClip eatFruitSound;


	static AudioSource AudioSource;
	// Use this for initialization
	void Start () {
		startSound = Resources.Load<AudioClip>("start");

		munch1Sound = Resources.Load<AudioClip>("munch_1");
		munch2Sound = Resources.Load<AudioClip>("munch_2");

		deathSound = Resources.Load<AudioClip>("death");
		eatFruitSound = Resources.Load<AudioClip>("eat_fruit");

		AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}	

	public static void PlaySound (string clip)
	{
		switch (clip)
		{	
			case "start":
				AudioSource.PlayOneShot(startSound);
				break;	
			case "munch_1":
				AudioSource.PlayOneShot(munch1Sound);
				break;	
			case "munch_2":
				AudioSource.PlayOneShot(munch2Sound);
				break;	
			case "eat_fruit":
				AudioSource.PlayOneShot(eatFruitSound);
				break;				
			case "death":
				AudioSource.PlayOneShot(deathSound);
				break;				
		}
	}
	
}
