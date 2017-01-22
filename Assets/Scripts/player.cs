using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private bool gameStart;
	private Rigidbody rg;
	private BoxCollider boxCollider;
	private bool waveEnabled;
	private float originX;
	private Quaternion originRotation;
	private int currentModel = 0;
	[SerializeField] private List<GameObject> models;

	public GameObject weather;

	public Transform sparkle;
	public PlusUpParticleManager plusup;
	[SerializeField] private WaveCalculator waveCalc;
	public int health = 3;

	PlayerAudio playerAudio;
	
	// Use this for initialization
	private float speed = 5f;
	void Awake () {
		originX = transform.localPosition.x;

		rg = GetComponent<Rigidbody>();
		boxCollider = GetComponent<BoxCollider>();
		UpdateModel();

		originRotation = sparkle.transform.localRotation;
		sparkle.GetComponent<ParticleSystem> ().enableEmission = false;
		playerAudio = GetComponent<PlayerAudio>();
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
		weather.SetActive (true);
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

	private void UpdateModel()
	{
		for (int i = 0; i < models.Count; i++)
		{
			if (i == currentModel)
			{
				var childCollider = models[i].gameObject.GetComponent<BoxCollider>();
				boxCollider.center = childCollider.center;
				boxCollider.size = childCollider.size;
				models[i].SetActive(true);
			}
			else
			{
				models[i].SetActive(false);
			}
		}
	}

	public void LevelUp()
	{
		++currentModel;
		if (currentModel >= models.Count)
		{
			currentModel = models.Count - 1;
		}

		UpdateModel();
		plusup.Enable(true);
		waveCalc.amplitute += 10f;
		waveCalc.waveLength *= 0.9f;
		playerAudio.playSounds(PlayerAudio.Sounds.LEVEL_UP);
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
	public void SpeedCut(float speedModity)
	{
		rg.AddForce(Vector3.forward*speed*speedModity);
	}
	public void JumpUp(float speedModify)
	{
		rg.AddForce(Vector3.up*speedModify);
	}

	public void Hurt()
	{
		--health;
	}

	public void OnCollisionEnter(Collision col)
	{
		var coollidable = col.gameObject.GetComponent<ICollidable>();
		if (coollidable != null)
		{
			coollidable.OnCollisionEnter(this);
		}
	}

	public void OnTriggerEnter(Collider col)
	{
		var triggable = col.gameObject.GetComponent<ITriggable>();
		if (triggable != null)
		{
			triggable.OnTriggerEnter(this);
		}
	}

    public void OnTriggerExit(Collider col)
    {
        var triggable = col.gameObject.GetComponent<ITriggable>();
        if (triggable != null)
        {
            triggable.OnTriggerExit(this);
        }
    }
}
