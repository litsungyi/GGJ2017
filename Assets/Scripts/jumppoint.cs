using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppoint : MonoBehaviour, ICollidable
{
	[Range(10, 1000)]
	[SerializeField] private float speedModify = 500f;

	// Use this for initialization
	void Start () {
		//rg = GetComponents<Rigidbody> ();	
	}

	#region ICollidable implementation

	void ICollidable.OnCollisionEnter(player target)
	{
		//target.JumpUp(speedModify);
	}

	void ICollidable.OnCollisionExit(player target)
	{
	}

	#endregion
}
