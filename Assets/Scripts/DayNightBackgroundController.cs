using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightBackgroundController : MonoBehaviour {
    [SerializeField]
    public Transform player;
    float currentPlayerZ;
    // Use this for initialization
    void Start () {
        currentPlayerZ = player.localPosition.z;

    }
	
	// Update is called once per frame
	void Update () {
        //update when move 10
        if ((player.localPosition.z ) > currentPlayerZ)
        {
            transform.Rotate(new Vector3(0, 0, player.localPosition.z-currentPlayerZ));
            currentPlayerZ = player.localPosition.z ;
           
        }
    }
}
