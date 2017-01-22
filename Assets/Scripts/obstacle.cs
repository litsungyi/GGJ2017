using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour, ICollidable
{
	private Renderer rend;
	
	GameObject player;
	PlayerAudio playerAudio;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAudio = player.GetComponent<PlayerAudio>();
	}

	#region ICollidable implementation

	void ICollidable.OnCollisionEnter(player target)
	{
		rend.material.color = Color.red;
		playerAudio.playSounds(PlayerAudio.Sounds.MONSTER_YELL);
		target.Hurt();
	}

	void ICollidable.OnCollisionExit(player target)
	{
	}

	#endregion
}
