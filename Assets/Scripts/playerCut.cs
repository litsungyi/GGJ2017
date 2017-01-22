using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCut : MonoBehaviour {
	
	public GameObject fire;
	GameObject player;
	PlayerAudio playerAudio;
	
	
	// Use this for initialization
	void Start () {
		fire.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("player");
		playerAudio = player.GetComponent<PlayerAudio>();
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.collider.name == "player") {
			Destroy (gameObject);
			fire.SetActive (true);
			playerAudio.playSounds(PlayerAudio.Sounds.EXPLOSION);
			StartCoroutine (stopfire ());
		}
	}
	IEnumerator stopfire()
	{
		yield return new WaitForSeconds (1f);
		fire.GetComponent<ParticleSystem>().enableEmission = false;
	}
}
