using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private player target;
	[SerializeField] private float pressThreshold = 0.8f;
	[SerializeField] private float fireThreshold = 3f;
	private float fireCooldown = 0;

	private bool pressed;
	private float pressDuration = 0f;

	void Update ()
	{
		if (target != null)
		{
			if (pressed)
			{
				pressDuration += Time.deltaTime;
				if (pressDuration >= pressThreshold)
				{
					target.UpdateBoost();
				}
			}

			if (Input.GetButtonDown("Jump"))
			{
				pressed = true;
				pressDuration = 0;
			}
			else if (Input.GetButtonUp("Jump"))
			{
				target.Jump();
				pressed = false;
				pressDuration = 0;
			}

			if (Input.GetButton("Fire1"))
			{
				if (Time.time >= fireCooldown)
				{
					fireCooldown = Time.time + fireThreshold;
					target.Fire();
				}
			}

			target.Move(Time.deltaTime);
		}
	}
}
