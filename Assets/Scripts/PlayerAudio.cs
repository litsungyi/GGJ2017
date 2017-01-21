using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour {

	public enum Sounds{BABY_HURT, BABY_DEAD, BABY_JUMP};
	AudioSource player_audio;  
	
	public AudioClip babyHurt;  								// The audio clip to play when the player get hurt.
    public AudioClip babyDeath;                                 // The audio clip to play when the player dies.
	public AudioClip babyJump;								
	
	// Use this for initialization
	void Awake () {	
			player_audio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void playSounds(Sounds clip)
	{
		switch(clip){
			case Sounds.BABY_HURT:
				player_audio.clip = babyHurt;
				 player_audio.Play ();
				 break;
			case Sounds.BABY_DEAD:
				player_audio.clip = babyDeath;
				 player_audio.Play ();
				 break;
			case Sounds.BABY_JUMP:
				player_audio.clip = babyJump;
				 player_audio.Play ();
				 break;
			
		}
		
	}
}
