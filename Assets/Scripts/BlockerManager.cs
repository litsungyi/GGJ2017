using System.Collections;

using System.Collections.Generic;
using Camus;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BlockerManager : MonoBehaviour
{
	public GameObject blockerPrefab1;
	public GameObject blockerPrefab2;

	public GameObject blockerRoot1;
	public GameObject blockerRoot2;

	public List<Vector3> blocker1Positions;
	public List<Vector3> blocker2Positions;

	private void Awake()
	{
		GenerateBlockers();
	}

	private void Update ()
	{
		
	}

	public void GenerateBlockers()
	{
		foreach (var item in blocker1Positions)
		{
			var blocker = blockerRoot1.Append(blockerPrefab1);
			blocker.transform.position = item;
		}

		foreach (var item in blocker2Positions)
		{
			var blocker = blockerRoot2.Append(blockerPrefab2);
			blocker.transform.position = item;
		}
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(BlockerManager))]
public class BlockerManagerEditor : Editor
{
	private List<GameObject> blockers1 = new List<GameObject>();
	private List<GameObject> blockers2 = new List<GameObject>();

	public void OnEnable()
	{
		var manager = target as BlockerManager;
		blockers1 = new List<GameObject>();
		for(int i = 0; i < manager.blockerRoot1.transform.childCount; i++)
		{
			var obj = manager.blockerRoot1.transform.GetChild(i).gameObject;
			blockers1.Add(obj);
		}

		blockers2 = new List<GameObject>();
		for(int i = 0; i < manager.blockerRoot2.transform.childCount; i++)
		{
			var obj = manager.blockerRoot2.transform.GetChild(i).gameObject;
			blockers2.Add(obj);
		}
	}

	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();

		var manager = target as BlockerManager;
		if(GUILayout.Button("Save"))
		{
			Save(blockers1, manager.blocker1Positions, manager.blockerRoot1, manager.blockerPrefab1);
			Save(blockers2, manager.blocker2Positions, manager.blockerRoot2, manager.blockerPrefab2);
		}

		if(GUILayout.Button("Load"))
		{
			Load(blockers1, manager.blocker1Positions, manager.blockerRoot1, manager.blockerPrefab1);
			Load(blockers2, manager.blocker2Positions, manager.blockerRoot2, manager.blockerPrefab2);
		}
	}

	private void Save(List<GameObject> blockers, List<Vector3> blockerPositions, GameObject blockerRoot, GameObject blockerPrefab)
	{
		blockerPositions.Clear();
		for (int count = 0; count < blockers.Count; count++)
		{
			var blocker = blockers[count];
			blockerPositions.Add(blocker.transform.position);
			//PrefabUtility.ReplacePrefab(blocker, PrefabUtility.GetPrefabParent(blocker));

			EditorUtility.SetDirty(blocker);

			DestroyImmediate(blocker);
			blockers[count] = null;
		}
		blockers.Clear();
	}

	private void Load(List<GameObject> blockers, List<Vector3> blockerPositions, GameObject blockerRoot, GameObject blockerPrefab)
	{
		blockers.Clear();
		for (var count = 0; count < blockerPositions.Count; ++count)
		{
			var item = blockerPositions[count];
			var blocker = blockerRoot.Append(blockerPrefab);
			blocker.transform.position = item;
			blockers.Add(blocker);
		}
	}
#endif

}
