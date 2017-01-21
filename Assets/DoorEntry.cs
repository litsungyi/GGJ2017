using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntry : MonoBehaviour, ITriggable
{
	public GameObject doorExit;

	#region ITriggable implementation
	void ITriggable.OnTriggerEnter(player target)
	{
		target.transform.position = doorExit.transform.position;
	}

	void ITriggable.OnTriggerExit(player target)
	{
	}
	#endregion
}
