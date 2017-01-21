using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private Rigidbody rg;
	private float nextfire;
	private float originX;

	public Transform sparkle;
	[SerializeField] private WaveCalculator waveCalc;

	// Use this for initialization
	private float speed = 5f;
	void Start () {
		originX = transform.localPosition.x;
		rg = GetComponent<Rigidbody> ();
		sparkle.GetComponent<ParticleSystem> ().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.World);
		var localPosition = transform.localPosition;
		transform.localPosition = new Vector3(originX, localPosition.y, localPosition.z);
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

	public void SpeedUp(float speedModify)
	{
		rg.AddForce(Vector3.forward*speed*speedModify);
	}

	public void JumpUp(float speedModify)
	{
		rg.AddForce (Vector3.up*speedModify);
	}

	void OnCollisionEnter(Collision col)
	{
		var coollidable = col.gameObject.GetComponent<ICollidable>();
		if (coollidable != null)
		{
			coollidable.OnCollisionEnter(this);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		var triggable = col.gameObject.GetComponent<ITriggable>();
		if (triggable != null)
		{
			triggable.OnTriggerEnter(this);
		}
	}

}
