using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCalculator : MonoBehaviour
{
	[Range(1, 10)]
	public float amplitute;

	[Range(1, 10)]
	public float waveLength;

	private float delta
	{
		get;
		set;
	}

	public float value
	{
		get
		{
			return amplitute * Mathf.Sin(Mathf.PI * delta / waveLength);
		}
	}

	private void Awake()
	{
		if (waveLength <= 0)
		{
			waveLength = 1f;
		}
	}

	private void OnEnable()
	{
		delta = 0f;
	}

	private void Update()
	{
		delta += Time.deltaTime;
	}

	private void FixedUpdate()
	{
		Debug.Log(this.value);
	}

}
