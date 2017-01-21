using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppoint : MonoBehaviour {
	//private Rigidbody rg;

	// Use this for initialization
	void Start () {
		//rg = GetComponents<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.collider.name == "player") {
			col.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up*500);
		}
	}
}
