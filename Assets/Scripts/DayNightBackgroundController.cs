using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightBackgroundController : MonoBehaviour {
    [SerializeField]
    public Transform player;
    float currentPlayerZ;
    float defaultHight;
    // Use this for initialization
    void Start () {
        currentPlayerZ = player.localPosition.z;
        defaultHight = player.localPosition.y;
        Invoke("adjustJump", 0);
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

    void adjustJump()
    {
        transform.localPosition = (new Vector3(0, (defaultHight - player.localPosition.y)*50, 0));
        Invoke("adjustJump", 0.05f);
    }


}
