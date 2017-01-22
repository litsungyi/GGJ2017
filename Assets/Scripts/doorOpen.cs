using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour, ITriggable
{
    private Animator doorAnimator;
    [SerializeField]
    public GameObject door;
    [SerializeField]
    public bool isFastOpen;
    void start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }
    #region ITriggable implementation
    void ITriggable.OnTriggerEnter(player target)
    {
        doorAnimator = door.GetComponent<Animator>();
        //open door
        if (isFastOpen)
            doorAnimator.SetTrigger("FastOpen");
        else
            doorAnimator.SetTrigger("Open");
        Debug.Log("EEEEEEEEEEEEEEEE");
    }



    void ITriggable.OnTriggerExit(player target)
    {
        Debug.Log("DDDDDDDDDDDDDDDDDD");
        doorAnimator = door.GetComponent<Animator>();
        //close door
        doorAnimator.SetTrigger("Close");
    }
    #endregion



}