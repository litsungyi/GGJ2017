using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusUpParticleManager : MonoBehaviour
{
	public List<ParticleSystem> particles;

	private void Awake()
	{
		Enable(false);
	}

	public void Enable(bool enabled)
	{
		foreach (var item in particles)
		{
			item.enableEmission = enabled;
		}
	}
}
