using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour {

	public enum Sounds{
	                                  ADULT_SCREAM,
									  ADULT_WALK,
									  BABY_HURT,  
									  BABY_LAUGH,
									  BABY_WALK,
									  EXPLOSION,
									  FEMALE_LAUGH,
									  FEMALE_SCREAM,
									  HIT,
	                                  JUMP,
									  LEVEL_UP,
									  MONSTER_YELL,
									  PICK_COIN,
									  POWER_UP
	                                  };
	AudioSource player_audio;  
	
	public AudioClip adultScream;
    public AudioClip adultWalk;
	public AudioClip babyHurt; 
	public AudioClip babyLaugh;
    public AudioClip babyWalk;    
	public AudioClip explosion; 
	public AudioClip femaleLaugh;
    public AudioClip femaleScream;
    public AudioClip hit;
	public AudioClip jump;
	public AudioClip levelUp;
    public AudioClip monsterYell;         		                      
	public AudioClip pickCoin;
	public AudioClip powerUp;
	// Use this for initialization
	void Awake () {	
			player_audio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void playSounds(Sounds clip)
	{
		bool soundsExist = true;
		
		switch(clip){
			case Sounds.ADULT_SCREAM:
				player_audio.clip = adultScream;
				 break;
			case Sounds.ADULT_WALK:
				player_audio.clip = adultWalk;
				 break;
			case Sounds.BABY_HURT:
				player_audio.clip = babyHurt;
				 break;
			case Sounds.BABY_LAUGH:
				player_audio.clip = babyLaugh;
				 break;
			case Sounds.BABY_WALK:
				player_audio.clip = babyWalk;
				 break;
			case Sounds.EXPLOSION:
				player_audio.clip = explosion;
				 break;
			case Sounds.FEMALE_LAUGH:
				player_audio.clip = femaleLaugh;
				 break;
			case Sounds.FEMALE_SCREAM:
				player_audio.clip = femaleScream;
				 break;
			case Sounds.HIT:
				player_audio.clip = hit;
				 break;
			case Sounds.JUMP:
				player_audio.clip = jump;
				 break;
			case Sounds.LEVEL_UP:
				player_audio.clip = levelUp;
				 break;
			case Sounds.MONSTER_YELL:
				player_audio.clip = monsterYell;
				 break;
			case Sounds.PICK_COIN:
				player_audio.clip = pickCoin;
				 break;
			case Sounds.POWER_UP:
				player_audio.clip = powerUp;
				 break;
			default :
				soundsExist = false;
				break;
		}
		
		if(soundsExist) player_audio.Play ();
	}
}
