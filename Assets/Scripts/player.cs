using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private Rigidbody rg;
	private bool waveEnabled;
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

	IEnumerator stopSparkles()
	{
		yield return new WaitForFixedUpdate();
		sparkle.GetComponent<ParticleSystem>().enableEmission = false;
	}

	public void Move(float deltaTime)
	{
		transform.Translate (Vector3.forward * speed *deltaTime, Space.World);
		var localPosition = transform.localPosition;
		transform.localPosition = new Vector3(originX, localPosition.y, localPosition.z);
	}

	public void UpdateBoost()
	{
		if (!waveEnabled)
		{
			waveEnabled = true;
			waveCalc.enabled = true;
			// TODO: Set waveCalc.amplitute & waveCalc.waveLength
		}
	}

	public void Jump()
	{
		if (waveEnabled)
		{
			var value = waveCalc.value;
			Debug.Log(value);
			rg.velocity = new Vector3(0, value, 0);
			waveEnabled = false;
			waveCalc.enabled = false;
		}
		else
		{
			rg.velocity = new Vector3(0, 8, 0);
		}

		sparkle.GetComponent<ParticleSystem>().enableEmission = true;
		StartCoroutine(stopSparkles());
	}

	public void Fire()
	{
		rg.velocity = new Vector3(0, 5, 6);
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
