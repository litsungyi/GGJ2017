using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, ITriggable
{
	[SerializeField] private Rigidbody trapItem;

	private void Awake()
	{
		trapItem.gameObject.SetActive(false);
	}

	#region ITriggable implementation

	void ITriggable.OnTriggerEnter(player target)
	{
		trapItem.gameObject.SetActive(true);
		trapItem.useGravity = true;
	}

	void ITriggable.OnTriggerExit(player target)
	{
	}

	#endregion
}
