using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Transform player;
    private int age ;
    private Text ageTxt;
	// Use this for initialization
	void Start () {
        age = 0;
        ageTxt = transform.FindChild("ageField/ageTxt").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		if(((int)player.localPosition.z/10)> age)
        {
            age = ((int)player.localPosition.z / 10);
            ageTxt.text = age.ToString();
        }
	}
}
