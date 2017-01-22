using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceItem : MonoBehaviour, ICollidable
{
	[Range(10, 1000)]
	[SerializeField] private float speedModify = 50f;
	
	GameObject player;
	PlayerAudio playerAudio;
	
	#region ICollidable implementation
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAudio = player.GetComponent<PlayerAudio>();
	}

	void ICollidable.OnCollisionEnter(player target)
	{
		target.SpeedUp(speedModify);
		playerAudio.playSounds(PlayerAudio.Sounds.SPEED_UP);
		Destroy(gameObject);
	}

	void ICollidable.OnCollisionExit(player target)
	{
	}

	#endregion
}
