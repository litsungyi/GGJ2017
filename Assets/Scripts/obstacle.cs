using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour, ICollidable
{
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}

	#region ICollidable implementation

	void ICollidable.OnCollisionEnter(player target)
	{
		rend.material.color = Color.red;
	}

	void ICollidable.OnCollisionExit(player target)
	{
	}

	#endregion
}
