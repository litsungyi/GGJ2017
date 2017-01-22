using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightBackgroundController : MonoBehaviour {
    [SerializeField]
    public Transform player;
    [SerializeField]
    public Image BabyBg;
    [SerializeField]
    public Image KidBg;
    [SerializeField]
    public Image AdultBg;
    [SerializeField]
    public Image ElderBg;
    float currentPlayerZ;
    float defaultHight;
    int currentBgID = 0;
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
        BackgroundChangeByAge();
    }

    void adjustJump()
    {
        transform.localPosition = (new Vector3(0, (defaultHight - player.localPosition.y)*10, 0));
        Invoke("adjustJump", 0.05f);
    }

    void BackgroundChangeByAge()
    {
        if (currentBgID < (int)player.GetComponent<player>().age)
        {
            currentBgID++;
            Debug.Log(currentBgID);
            switch (currentBgID)
            {
                case 1:
                    BabyBg.CrossFadeAlpha(0, 5, false);
                    break;
                case 2:
                    KidBg.CrossFadeAlpha(0, 5, false);
                    break;
                case 3:
                    AdultBg.CrossFadeAlpha(0, 5, false);
                    break;

            }
        }
    }
}
