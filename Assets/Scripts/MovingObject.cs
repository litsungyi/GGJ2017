using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
	[SerializeField] private Animator anim;
	public string trigger = string.Empty;

	// Use this for initialization
	private void Start ()
	{
		anim.SetTrigger(trigger);
	}
}
