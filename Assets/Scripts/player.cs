using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private Rigidbody rg;

	// Use this for initialization
	private float speed = 5f;
	void Start () {
		rg = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward *speed* Time.deltaTime,Space.World);
		if(Input.GetButtonDown("Jump")) {
			rg.velocity = new Vector3 (0, 8, 0);
		}

	}
	void OnTriggerEnter(Collider col)
	{
		if (col.name == "door") {
			transform.position = new Vector3 (-3.87f, 0.69f, -2.78f);
		}
	}
}
