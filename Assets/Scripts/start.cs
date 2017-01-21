using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start : MonoBehaviour {
    [SerializeField]
    private Button startBtn;
   
    // Use this for initialization
    void Start () {
        startBtn.onClick.AddListener(go);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void go()
    {
        this.gameObject.SetActive(false);
    }
}
