using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassToPlayer : MonoBehaviour
{
	private player target;
	private Camera camera;

	private void Awake()
	{
		target = GameObject.FindObjectOfType<player>();
		camera = target.gameObject.GetComponentInChildren<Camera>();
		var position = camera.transform.localPosition;
		camera.transform.localPosition = position;
	}

	void OnCollisionEnter(Collision col)
	{
		if (target != null)
		{
			target.OnCollisionEnter(col);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (target != null)
		{
			target.OnTriggerEnter(col);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (target != null)
		{
			target.OnTriggerExit(col);
		}
	}
}
