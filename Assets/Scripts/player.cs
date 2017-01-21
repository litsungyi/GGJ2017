using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private Rigidbody rg;
	private float nextfire;

	public Transform sparkle;
	[SerializeField] private WaveCalculator waveCalc;

	// Use this for initialization
	private float speed = 5f;
	void Start () {
		rg = GetComponent<Rigidbody> ();
		sparkle.GetComponent<ParticleSystem> ().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.World);
		if (Input.GetButtonDown ("Jump")) {
			rg.velocity = new Vector3 (0, 8, 0);
		}
		if (Input.GetButton ("Fire1") && Time.deltaTime > nextfire) {
			rg.velocity = new Vector3 (0, 5, 6);
			sparkle.GetComponent<ParticleSystem> ().enableEmission = true;
			StartCoroutine (stopSparkles ());
		}
	}
	IEnumerator stopSparkles()
	{
		yield return new WaitForFixedUpdate();
		sparkle.GetComponent<ParticleSystem>().enableEmission = false;
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "plus obj") {
			Destroy (col.gameObject);
			rg.AddForce (Vector3.forward*speed*50f);
		}
	}



	void OnTriggerEnter(Collider col)
	{
		var triggable = col.gameObject.GetComponent<ITriggable>();
		if (triggable != null)
		{
			triggable.OnTrige(this);
		}
	}

}
