using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, ITriggable
{
	[SerializeField] private Rigidbody trapItem;

	GameObject player;
	PlayerAudio playerAudio;
	
	private void Awake()
	{
		trapItem.gameObject.SetActive(false);
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAudio = player.GetComponent<PlayerAudio>();
	}

	#region ITriggable implementation

	void ITriggable.OnTriggerEnter(player target)
	{
		trapItem.gameObject.SetActive(true);
		trapItem.useGravity = true;
		playerAudio.playSounds(PlayerAudio.Sounds.FALLING);
	}

	void ITriggable.OnTriggerExit(player target)
	{
	}

	#endregion
}
