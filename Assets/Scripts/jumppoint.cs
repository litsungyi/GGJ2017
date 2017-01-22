using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppoint : MonoBehaviour, ICollidable
{
	[Range(10, 1000)]
	[SerializeField] private float speedModify = 500f;

	GameObject player;
	PlayerAudio playerAudio;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAudio = player.GetComponent<PlayerAudio>();
	}

	#region ICollidable implementation

	void ICollidable.OnCollisionEnter(player target)
	{
		target.JumpUp(speedModify);
		playerAudio.playSounds(PlayerAudio.Sounds.SPEED_UP);
		Destroy(gameObject);
	}

	void ICollidable.OnCollisionExit(player target)
	{
	}

	#endregion
}
