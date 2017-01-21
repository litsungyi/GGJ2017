using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntry : MonoBehaviour, ITriggable
{
	public GameObject doorExit;

	#region ITriggable implementation

	void ITriggable.OnTrige(player target)
	{
		target.transform.position = doorExit.transform.position;
	}

	#endregion
}
