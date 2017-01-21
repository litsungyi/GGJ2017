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
									  POWER_UP,
									  JET
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
	public AudioClip jet;

	AudioClip bgSound = null;
	float timeStemp;
	
	// Use this for initialization
	void Awake () {	
			player_audio = GetComponent <AudioSource> ();
			bgSound = null;
			player_audio.clip = bgSound;
	        timeStemp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
			if(bgSound != null && Time.time - timeStemp > 1){
				player_audio.Play();
				timeStemp = Time.time;
			}
	}
	
	public void playSounds(Sounds clip)
	{
		AudioClip playClip = null;
		switch(clip){
			case Sounds.ADULT_SCREAM:
				playClip = adultScream;
				 break;
			case Sounds.ADULT_WALK:
				playClip = adultWalk;
				 break;
			case Sounds.BABY_HURT:
				playClip = babyHurt;
				 break;
			case Sounds.BABY_LAUGH:
				playClip = babyLaugh;
				 break;
			case Sounds.BABY_WALK:
				playClip = babyWalk;
				 break;
			case Sounds.EXPLOSION:
				playClip = explosion;
				 break;
			case Sounds.FEMALE_LAUGH:
				playClip = femaleLaugh;
				 break;
			case Sounds.FEMALE_SCREAM:
				playClip = femaleScream;
				 break;
			case Sounds.HIT:
				playClip = hit;
				 break;
			case Sounds.JUMP:
				playClip = jump;
				 break;
			case Sounds.LEVEL_UP:
				playClip = levelUp;
				 break;
			case Sounds.MONSTER_YELL:
				playClip = monsterYell;
				 break;
			case Sounds.PICK_COIN:
				playClip = pickCoin;
				 break;
			case Sounds.POWER_UP:
				playClip = powerUp;
				 break;
			case Sounds.JET:
				playClip = jet;
				 break;
			default :
				//soundsExist = false;
				break;
		}
		
		if (playClip != null)
		{
			player_audio.PlayOneShot(playClip);
		}
		//player_audio.clip = bgSound;
	}
}
