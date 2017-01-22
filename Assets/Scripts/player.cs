using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private bool gameStart;
	private Rigidbody rg;
	private bool waveEnabled;
	private float originX;
	private Quaternion originRotation;

	public Transform sparkle;
	public PlusUpParticleManager plusup;
	[SerializeField] private WaveCalculator waveCalc;
	public int health = 3;

	PlayerAudio playerAudio;
	
	// Use this for initialization
	private float speed = 5f;
	void Awake () {
		originX = transform.localPosition.x;
		rg = GetComponent<Rigidbody> ();
		originRotation = sparkle.transform.localRotation;
		sparkle.GetComponent<ParticleSystem> ().enableEmission = false;
		playerAudio = GetComponent<PlayerAudio>();
		//playerAudio.playSounds(PlayerAudio.Sounds.BABY_HURT);
		gameStart = false;
	}

	IEnumerator stopSparkles()
	{
		yield return new WaitForSeconds(0.2f);
		sparkle.GetComponent<ParticleSystem>().enableEmission = false;
		sparkle.transform.localRotation = originRotation;
	}

	IEnumerator stopplusup()
	{
		yield return new WaitForSeconds(2f);
		plusup.Enable(false);
	}

	public void GameStart()
	{
		gameStart = true;
	}

	public void Move(float deltaTime)
	{
		if (!gameStart)
		{
			return;
		}

		transform.Translate (Vector3.forward * speed *deltaTime, Space.World);
		var localPosition = transform.localPosition;
		transform.localPosition = new Vector3(originX, localPosition.y, localPosition.z);
		
	}

	public void UpdateBoost()
	{
		if (!waveEnabled)
		{
			waveEnabled = true;
			//waveCalc.enabled = true;
			// TODO: Set waveCalc.amplitute & waveCalc.waveLength
		}
	}

	public void Jump()
	{
		playerAudio.playSounds(PlayerAudio.Sounds.JET);
		
		if (waveEnabled)
		{
			var value = waveCalc.value;
			Debug.Log(value);

			value *= 30f;
			if (value < 0)
			{
				value -= 100f;
				sparkle.transform.Rotate(40, 0, 0);
				//sparkle.transform.localRotation = new Quaternion(220, originRotation.y, originRotation.z, originRotation.w);
			}
			else
			{
				value += 100f;
			}
			JumpUp(value);
			waveEnabled = false;
			//waveCalc.enabled = false;
		}
		else
		{
			rg.velocity = new Vector3(0, 8, 0);
		}

		
		sparkle.GetComponent<ParticleSystem>().enableEmission = true;
		StartCoroutine(stopSparkles());
	}

	public void LevelUp()
	{
		plusup.Enable(true);
		waveCalc.amplitute += 10f;
		waveCalc.waveLength *= 0.9f;

		StartCoroutine (stopplusup ());
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
		rg.AddForce(Vector3.up*speedModify);
	}

	public void Hurt()
	{
		--health;
	}

	void OnCollisionEnter(Collision col)
	{
		var coollidable = col.gameObject.GetComponent<ICollidable>();
		if (coollidable != null)
		{
			coollidable.OnCollisionEnter(this);
		}
		playerAudio.playSounds(PlayerAudio.Sounds.JET);
	}

	void OnTriggerEnter(Collider col)
	{
		var triggable = col.gameObject.GetComponent<ITriggable>();
		if (triggable != null)
		{
			triggable.OnTriggerEnter(this);
		}
	}
    void OnTriggerExit(Collider col)
    {
        var triggable = col.gameObject.GetComponent<ITriggable>();
        if (triggable != null)
        {
            triggable.OnTriggerExit(this);
        }
    }
}
