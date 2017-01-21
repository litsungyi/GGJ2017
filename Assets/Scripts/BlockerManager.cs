using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Camus;

public class BlockerManager : MonoBehaviour
{
	[SerializeField] private GameObject blockerPrefab1;
	[SerializeField] private GameObject blockerPrefab2;

	[SerializeField] private GameObject blockerRoo1;
	[SerializeField] private GameObject blockerRoo2;

	[SerializeField] private List<Vector3> blocker1Positions;
	[SerializeField] private List<Vector3> blocker2Positions;

	private void Awake()
	{
		foreach (var item in blocker1Positions)
		{
			var blocker = blockerRoo1.Append(blockerPrefab1);
			blocker.transform.position = item;
		}

		foreach (var item in blocker2Positions)
		{
			var blocker = blockerRoo2.Append(blockerPrefab2);
			blocker.transform.position = item;
		}
	}

	private void Update ()
	{
		
	}

#region
	private void Edit()
	{
	}
#endregion

}
