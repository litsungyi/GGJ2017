using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCalculator : MonoBehaviour
{
	[SerializeField] private WaveDisplay display;

	[Range(1, 100)]
	public float amplitute;

	[Range(0, 10)]
	public float waveLength;

	private float delta
	{
		get;
		set;
	}

	public float xValue
	{
		get
		{
			return delta / waveLength;
		}
	}

	public float lastValue
	{
		get;
		private set;
	}

	public float value
	{
		get
		{
			lastValue = amplitute * Mathf.Sin(2 * Mathf.PI * xValue);
			return lastValue;
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
		display.UpdateWave(this);
	}

	private void FixedUpdate()
	{
		//Debug.Log(this.value);
	}
}
