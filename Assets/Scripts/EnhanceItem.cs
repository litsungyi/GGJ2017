using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceItem : MonoBehaviour, ICollidable
{
	[Range(10, 1000)]
	[SerializeField] private float speedModify = 50f;

	#region ICollidable implementation

	void ICollidable.OnCollisionEnter(player target)
	{
		target.SpeedUp(speedModify);
		Destroy(gameObject);
	}

	void ICollidable.OnCollisionExit(player target)
	{
	}

	#endregion
}
