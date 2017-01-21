using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle2 : MonoBehaviour {
	public GameObject fire;
	// Use this for initialization
	void Start () {
		fire.SetActive (false);

	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.collider.name == "player") {
			Destroy (gameObject);
			fire.SetActive (true);
			StartCoroutine (stopfire ());
		}
	}
	IEnumerator stopfire()
	{
		yield return new WaitForSeconds (2f);
		fire.GetComponent<ParticleSystem>().enableEmission = false;
	}
}
