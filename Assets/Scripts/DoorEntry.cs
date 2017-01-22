using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntry : MonoBehaviour, ITriggable
{
	public GameObject doorExit;

	GameObject player;
	PlayerAudio playerAudio;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAudio = player.GetComponent<PlayerAudio>();
	}
	
	#region ITriggable implementation
	void ITriggable.OnTriggerEnter(player target)
	{
		target.LevelUp();
		playerAudio.playSounds(PlayerAudio.Sounds.LEVEL_UP);
		target.transform.position = doorExit.transform.position;
	}

	void ITriggable.OnTriggerExit(player target)
	{
	}
	#endregion
}
